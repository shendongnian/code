    if (e.Exception.Message != null){
          if (e.Exception.Message.Contains("duplicate key")
           {
             Response.Write("Student already registered!");
             e.ExceptionHandled = true;
           }   
     }
