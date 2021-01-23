    class Runtime
    {
        private MyContext myContext;
        public static Mycontext GetMyContext()
        {
            return myContext;
        }
        public Runtime()
        {
            myContext = new MyContext();
            //cant pass my object in
            var myobject = new ClassThatNeedsAReferenceToMyContext();
            if(myobject.theContext == myContext)
            {
                Console.WriteLine("Yahoo");
            }
        }
    }
    class ClassThatNeedsAReferenceToMyContext
    {
        public ClassThatNeedsAReferenceToMyContext()
        {
            //do something here to get a reference to myContext
             theContext = Runtime.GetMyContext();
        }
        public MyContext theContext { get; private set; }
    }
