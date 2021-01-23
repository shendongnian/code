    public ActionResult Chart()
    {
       var Value1 = db.MYTABLE.Where(i => i.Value1);
       var Value2 = db.MYTABLE.Where(i => i.Value2);          
       var dataForChart = new[]
       {  
          new 
          {
             label = "Your Label1", 
             value = Value1.Count()
          },
          new 
          {
             label = "Your Label2", 
             value = Value2.Count()
          }                
       };
       var result = Json(dataForChart, JsonRequestBehavior.AllowGet);
       return result;
    
     }
