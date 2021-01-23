	public class HomeController: Controller
	{
		// foobar.com/home/123
		[Route("home/{id:int}")]
		public ActionResult Foo(int id)
		{
			return this.View();
		}
		
		// foobar.com/home/onetwothree
		[Route("home/{id:alpha}")]
		public ActionResult Bar(string id)
		{
			return this.View();
		}
	}
