    class MyConfig()
    {
       // your configuration members
    }
    class MyBLClass(MyConfig config)
    {
        private MyConfig _config;
        public MyBLClass(MyConfig config)
        {
            _config=config;
        }
        // use the _config in your class
    }
