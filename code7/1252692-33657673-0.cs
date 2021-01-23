	public class MyBaseController: Controller
	{
		[HttpGet]
		[Route("bar")]
		public virtual ActionResult MyAction(){
		{
			return Content("Hello stranger!");
		}
	}
