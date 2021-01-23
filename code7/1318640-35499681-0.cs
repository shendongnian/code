    public class A
    {
        public bool IsInitializationOk; //by default, this is false
        public A()
        {
            // DoSomething
            if(something is not correct)
                return;
            IsInitializationOk = true;
        }
    }
    
    public class B : A
    {
        public B() :base()
        {
            // Check if everything was fine in base class
            if (IsInitializationOk){
                //Do something.
            }
        }
    }
