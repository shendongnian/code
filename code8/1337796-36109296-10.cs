     public class MyEventController : Controller
     {
            
         [HttpPost]
         public ActionResult Save(InputEvent model)
         {     
             // Consider refining the implementation to use Stored Procedures or an ORM e.g. Entity Framework. 
             // It helps secure your app. Application security advice.    
             MySqlConnection conn = new MySqlConnection("mydbstring"); 
             conn.Open();                        
             MySql.Data.MySqlClient.MySqlCommand comm = conn.CreateCommand();
             comm.CommandText = "INSERT INTO event(title, address) VALUES(" + model.title + "," + model.address + ")";  
             comm.ExecuteNonQuery();
             conn.Close();    
             return View();
         }
    
         [HttpGet]
         public ActionResult Save()
         {                
             return View();
         }
     }
