	[RoutePrefix("foo")]
	public class MyController: MyBaseController
	{
		
		[HttpGet]
		[Route("foo")]
		public  ActionResult MyAction(){
		{
			return Content("Hello stranger!");
		}
	}
