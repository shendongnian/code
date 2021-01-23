        public static void Main()
        {
            TestDelegate del = new TestDelegate(Notify);
            del("Hello");
            //Store the return value in a new delegate
            TestDelegate del2 = WrapCallback(del);
            //And then call that delegate.  Note that TestDelegate takes a string as a parameter
            del2("This string does nothing");
            //Alternatively, call the delegate at the same time it's returned, but don't store it
            WrapCallback(del)("This string does nothing");
        }
