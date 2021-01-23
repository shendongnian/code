    public class TestController : Controller
    {
        public async Task<object> GetPlaces()
        {
            return Json(await PlacesHelper.LoadPlacesAsync(), JsonRequestBehavior.AllowGet);
        }
    }
