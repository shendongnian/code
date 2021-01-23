    class Test
    {
        public void Fun<T1, T2>(T1 a, Func<T1, T2> f)
        {
        }
    
        public string Fun2(int test)
        {
            return test.ToString(); 
        }
    
        public Test()
        {
            Fun(0, Fun2);
        }
    }
