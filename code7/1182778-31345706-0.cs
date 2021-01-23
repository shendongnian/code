    class MyClass
    {
        private static int _property = 0;
        public static object Property
        {
            get
            {
                return _property;
            }
            set
            {
                _property = Convert.ToInt32(value);
            }
        }
    }
