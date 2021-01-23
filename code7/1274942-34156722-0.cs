    public class HomeController : Controller
    {    
      public async Task<ViewResult> CarsSync() 
      {
        SampleAPIClient client = new SampleAPIClient();
        var cars = await client.GetCarsInAWrongWayAsync();
        return View("Index", model: cars);
      }
    }
