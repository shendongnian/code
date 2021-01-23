    class D
    {
        public void SomeMethod<T>(T t) where T : class
        {
            if (t is A)
                A a = t as A;
            else if (t is B)
                B b = t as B;
            else
                throw new Exception("Wrong class type.");
        }
    }
