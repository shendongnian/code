    using OtherClassA = OutsideLibrary.Class1;
    namespace Any.Namespace.01
    {
        public class ClassA 
        {
            public void Method1() 
            {
                OtherClassA.DoOperation();
            }
        }
    }
