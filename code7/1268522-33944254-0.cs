    interface SomeInterface
    {
        void SomeMethod();
    }
    class SomeClass : SomeInterface
    {
        public void SomeMethod() //This will be marked as virtual final in IL
        {
            //anything
        }
    }
