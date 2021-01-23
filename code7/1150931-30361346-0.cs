    class B
    {
        public B() {}
    
        public void h(Action a)
        {
            a();
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
