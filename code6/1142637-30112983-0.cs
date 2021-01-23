    static class G //static is not necessary here
    {
        public static bool testMode;
    }
    class test
    {
        test()
        {
            G.testMode = true;  // read from the database.
            // more code...
            Object1 _obj = new Object1();
            // do more stuff with _obj...
        }
    }
    
    class Object1
    {
    
        public Object1()
        {
            // constructor
            if (G.testMode)          // << I'd like to just refer to it this way!
            {
                // do something
            }
        }
    }
