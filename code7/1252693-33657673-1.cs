	[RoutePrefix("foo")]
	public class MyController: MyBaseController
	{
		
		[HttpGet]
		[Route("foo")]
		public override ActionResult MyAction(){
		{
			return Content("Hello stranger!");
		}
	}
