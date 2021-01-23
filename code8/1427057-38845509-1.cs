    class Program : child
    {
        void Method()
        {
            Program p1 = new Program();
            p1.printFirstName(); // this works
  
            child c1 = new child();
            p1.printFirstName(); // this gives your compiler error
    }
