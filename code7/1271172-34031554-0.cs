    public class HomeController : Controller
        {
    
            public class SqlParams 
            {
                public string Name { get; set; }
                public string Value { get; set; }
                public string ParamType { get; set; }
    
            }
    
            public ActionResult SQL() 
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult SQL(List<SqlParams> sqlParams)
            {
    
                foreach (var item in sqlParams)
                {
                    //Do whatever 
                    string query = string.Format("{0} = {1}, {2}",item.Name,item.Value, item.ParamType);                
                }
    
                return View();
            }
    }
