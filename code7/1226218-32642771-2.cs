    public class ParentClass
    {
        private class InternalClass
        {
            public void PublicMethod() { }
            private void PrivateMethod() { }
        }
        private void SomeMethod()
        {
            //InternalClass can only be created by methods of ParentClass
            var ic = new InternalClass();
            ic.PublicMethod();      //Internally visible
            ic.PrivateMethod();     //Invalid, not accessible
        }
    }
