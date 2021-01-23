    public class StatisticsController : Controller
    {    
        [HttpPost]
        public ActionResult displayChart()
        {
            var results = Json(DAL.StatisticsAccess.getTypesForStatistics());
            return results;
        }
    }
