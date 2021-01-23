     public class HomeController : Controller
     {       
         public ActionResult Index()
         {             
             MySQL msql = new MySQL();                          
             var results = msql.SelectList("Select columns from table");
             // create your collection of the correct size since the beginning
             var model = new List<BoxStatusModel>(results.Count);
             for (int i = 0; i < results.Count; i++)
             {
                 model.Add(new BoxStatusModel() {
                    // I am not familiar with the MySQL but should be something like this
                    BoxID = results[i].GetValue("BoxID");
                    CurrentStatus = results[i].GetValue("CurrentStatus");
                 });
             }
             return View(model);
         }   
    }
