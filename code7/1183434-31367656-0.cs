    public interface ISomeClass
        {
            /// <summary>
            /// eample class method
            /// </summary>
            /// <returns></returns>
            string doSomething();
        }
    
        public class SomeClassA : ISomeClass
        {
            public string doSomething()
            {
                return "A";
            }
        }
    
        public class SomeClassB : ISomeClass
        {
            public string doSomething()
            {
                return "B";
            }
        }
    
        public class SomeClassC : ISomeClass
        {
            public string doSomething()
            {
                return "C";
            }
        }
    
        public class SomeClassD : ISomeClass
        {
            public string doSomething()
            {
                return "D";
            }
        }
    
        public class Class1
        {
            private SomeClassA A;
            private SomeClassB B;
            private SomeClassC C;
            private SomeClassD D;
    
            private enum SomeEnum { A, B, C, D };
    
            private void SomeMethod(SomeEnum theEnum, ISomeClass theNewValue)
            {
                ISomeClass oldValue = GetSomeClass(theEnum);
                oldValue = theNewValue;
            }
    
            private ISomeClass GetSomeClass(SomeEnum theEnum)
            {
                switch (theEnum)
                {
                    case SomeEnum.A:
                        return A;
                    case SomeEnum.B:
                        return B;
                    case SomeEnum.C:
                        return C;
                    case SomeEnum.D:
                        return D;
                }
    
                return null;
            }
        }
