    class TestClass
    {
        public static void TestStaticMethod()
        {
            TestClass instance = new TestClass();
            instance.PrivateMethod();
        }
        private void PrivateMethod()
        { 
            //Do Something
        }
    }
