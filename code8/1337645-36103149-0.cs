	public class HomeController : Controller { //suppose this is your Home
		public ActionResult Index() {
            IEnumerable<OdeToFood.Models.RestaurantReview> model;
            model = from m in db.RestaurantReviews
                    ... //your query here
                    select m;
			return View(model); //pass the model here
		}
