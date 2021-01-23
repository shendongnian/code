	public interface IBookingProcessor
	{
		ProcessViewModel Process(ProcessViewModel model);
	}
	public class BookingProcessor : IBookingProcessor
	{
		public ProcessViewModel Process(ProcessViewModel model)
		{
			// Add the common logic here
		}
	}
	public class BookingController : Controller
	{
		private readonly IBookingProcessor bookingProcessor;
		
		public BookingController(IBookingProcessor bookingProcessor)
		{
			if (bookingProcessor == null)
				throw new ArgumentNullException("bookingProcessor");
			this.bookingProcessor = bookingProcessor;
		}
		
		[HttpPost]
		public ActionResult Process(ProcessViewModel model)
		{
			var vm = this.bookingProcessor.Process(model);
			
			//set some properties on vm as needed
			
			//Return the result
			return View(vm);
		}
	}
	public class QuoteController : Controller
	{
		private readonly IBookingProcessor bookingProcessor;
		
		public BookingController(IBookingProcessor bookingProcessor)
		{
			if (bookingProcessor == null)
				throw new ArgumentNullException("bookingProcessor");
			this.bookingProcessor = bookingProcessor;
		}
		
		[HttpPost]
		public ActionResult Process(ProcessViewModel model)
		{
			var vm = this.bookingProcessor.Process(model);
			
			//set some properties on vm as needed
			
			//Return the result
			return View(vm);
		}
	}
