    // if this is your model ...
    public class MyModel 
    {
        public string FieldName {get;set;}
    }
    
    // this is what your Controler method would look like 
    public ActionResult Check(string fieldname, string fieldValue)
    {
       var tablename = new MyModel{ FieldName = "check"};
       var prop = typeof(MyModel).GetProperty(fieldname); 
       var value = prop.GetValue(tablename);
    
       // do notice value is here an Object, so you might want to Convert or Cast if needed
       if (value == fieldValue) 
       {
          "equal".Dump();
       }
       return View(tablename);
    }
    // and this is how your Controller method gets called
    Check("FieldName","check");
