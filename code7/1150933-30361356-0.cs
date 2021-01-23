    class B
    {
        public B()
        {
        }
        public void h(Action func)
        {
            func.Invoke();
            // or
            func();
        }
    }
    class A
    {
        private int x = 0;
        private void g()
        {
            x = 5;
        }
        private void f()
        {
            B b = new B();
            b.h(g);
        }
    }
