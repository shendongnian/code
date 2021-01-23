    public class PublicClass
    {
        public void PublicMethod() 
        {
            ProtectedMethod();      //Valid call
            PrivateMethod();        //Also valid
        }
        protected void ProtectedMethod()
        {
            PublicMethod();         //Valid
            PrivateMethod();        //Valid
        }
        private void PrivateMethod()
        {
            PublicMethod();         //Valid
            PrivateMethod();        //Valid
        }
    }
    public class SomeOtherClass
    {
        public void SomeMethod()
        {
            PublicClass c = new PublicClass();
            c.PublicMethod();       //Valid
            c.ProtectedMethod();    //Invalid, not accessible
            c.PrivateMethod();      //Also invalid
        }
    }
