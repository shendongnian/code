        static void Main(string[] args)
        {
            int firstCallTimeOut = 0;
            int callInterval = 300000;
            object functionParam = new object();//optional can be null
            Timer timer = new Timer(foo,null,firstCallTimeOut,callInterval);
           
        }
        static void foo(object state)
        {
           //TODO
        }
