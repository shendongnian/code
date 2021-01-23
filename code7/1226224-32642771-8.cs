    public class ParentClass
    {
        private class NestedClass
        {
            public void PublicMethod() { }
            private void PrivateMethod() { }
        }
        private void SomeMethod()
        {
            //NestedClasscan only be created by methods of ParentClass
            var nc = new NestedClass();
            nc.PublicMethod();      //Internally visible
            nc.PrivateMethod();     //Invalid, not accessible
        }
    }
