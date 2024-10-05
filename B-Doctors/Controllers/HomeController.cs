using B_Doctors.Data;
using B_Doctors.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B_Doctors.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
		{
			return View();
		}

		
        public IActionResult Book_An_Appointment()
        {
			var doctors=context.Doctors.ToList();
            return View(model:doctors);

        }
        public IActionResult Booking(int DoctorId)
        {
			var booking = context.Doctors.Find(DoctorId);
            return View(model:booking);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
