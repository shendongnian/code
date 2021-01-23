    class MyClass
    {
       public void TargetMethod(Action callback)
       {
          Console.WriteLine("Inside TargetMethod");
    
          callback(); //This calls/notify the handler to do some stuff.
       }
    
       public void SourceMethod()
       {
          Console.WriteLine("Inside SourceMethod");
          TargetMethod(CallbackHandler); //Notice here we are calling to a handler which can do some stuff for us.
       }
    
       public void CallbackHandler()
       {
          Console.WriteLine("Inside CallbackHandler");
       }
    }
