    class Foo<T>()
    {
        List<T> TLS;
    
        public main()
        {
            launchThread(threadMethod1)
        }
    
        public void threadMethod1()
        {
            TLS = new List<T>()
            // TLS.Add(); HERE
            threadMethod2();
        }
    
        public void threadMethod2()
        {
            // TLS.Add(); HERE
        }
    }
