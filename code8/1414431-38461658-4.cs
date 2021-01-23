    public string DoFoo(A a)
        {
            string result = a.Foo();
            return result;
        }
    }
    
    sealed public class A
    {
        public string Foo()
        {
            throw new NotImplementedException();
        }
    }
