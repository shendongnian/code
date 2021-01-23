    class A
    {
        public void MethodInA();
    }
    
    class B
    {
         public void MethodInB();
    }
    
    class C
    {
        // pseudocode here!
        void Test<T>(T someObj) where T : A or B
        {
            // how it would behave if T is B?
            someObj.MethodInA();
            // how it would behave if T is A?
            someObj.MethodInB();
        }
    }
