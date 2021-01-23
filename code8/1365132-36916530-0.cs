      In Inheritance,
       If Derived class contains its own constructor which not defined in Base class then this error Occurs
    For Example:
     class FirstClass
       {
          public FirstClass(string s) { Console.WriteLine(s); }
       }
    class SecondClass : FirstClass
    {
        public SecondClass()
        {
            Console.WriteLine("second class");
        }
    }
    Output: Error:-'myconsole.FirstClass' does not contain a constructor that takes 0 arguments	
    To Run without Error:
     class FirstClass
    {
        public FirstClass()
        {
            Console.WriteLine("second class");
        }
      public FirstClass(string s) { Console.WriteLine(s); }
    }
    class SecondClass : FirstClass
    {
        public SecondClass()
        {
            Console.WriteLine("second class");
        }
    }
