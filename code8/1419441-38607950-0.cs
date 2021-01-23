       public class MyModel 
       {
           public string FieldName {get;set;}
       }
    
       var prop = typeof(MyModel).GetProperty(fieldname); 
       var value = prop.GetValue(tablename);
    
       // do notice value is here an Object, so you might want to Convert or Cast if needed
       if (value == "check") 
       {
          // do stuff
       }
