    class Test
    {
        public void Fun<T>(Func<T, T> f, T x)
        {
            f(x);
        }
        public string Fun2(string test)
        {
            return test;
        }
        public Test()
        {
            Fun(Fun2, "");
        }
    }
