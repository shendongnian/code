    public class StatisticsController : Controller
    {    
        [HttpPost]
        public ActionResult displayChart()
        {
            var results = DAL.StatisticsAccess.getTypesForStatistics();
            return Json(results);
        }
    }
