    public ActionResult MyController(FormCollection collection, YourModel model)
    {
        
       foreach (var x in model)
       {
          bool IsThisCheked= Convert.ToBoolean(collection[x.name].ToString());
       }
    }
