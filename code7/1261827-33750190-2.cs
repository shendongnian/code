    class MyClass
    {
       public void TargetMethod(Action callback)
       {
          Console.WriteLine("Inside TargetMethod");
    
          callback(); //This call the SourceMethod() and which inturn call TargetMethod() again in infinite recursion.
       }
    
       public void SourceMethod()
       {
          Console.WriteLine("Inside SourceMethod");
          TargetMethod(SourceMethod);       
       }
    }
    
    //Calling code
    MyClass objMyClass = new MyClass();
    objMyClass.SourceMethod();
