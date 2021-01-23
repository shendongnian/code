        namespace TheNUGETLibraryDll
    {
        public class SomeClass
        {
            public virtual void MethodToChange()
            { }
        }
    }
    
    namespace YourProject
    {
        public class DerivedClass : SomeClass
        {
            public override void MethodToChange()
            { }
        }
    }
