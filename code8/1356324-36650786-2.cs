    class A { }
    class B { }
    class C { }    
    class D
    {
        public void SomeMethod<T>(T t) where T : class
        {
            if (t is A)
            {
                A a = t as A;
            }
            else if (t is B)
            {
                B b = t as B;
            }
            else //if (t is C)
            {
                throw new ArgumentException();
            }
        }
    }
