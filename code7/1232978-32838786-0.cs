    class Base<T> 
    {
        protected T field1;
    }
    /*
     * Please note the Derived is not generic, only derives from generic class
     */
    class Derived : Base<string> 
    {
        /*
         * Here, I would like to use SomeType's "generic name" (like the T in the Base), 
         * so it might look like:
         */
        //[not necessary]
        //Base.T field1; // This would translate to 'SomeType field1' for this particular case
        public Derived()
        {
            field1 = "hello world";
        }
    }
