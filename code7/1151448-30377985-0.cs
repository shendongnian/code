    class A
    {
        protected void M1() { }
        protected void M2() { }
        protected void M3() { }
        protected void M4() { }
        protected void M5() { }
    }
    class B : A
    {
        public new void M1()
        {
            base.M1();
        }
        public new void M2()
        {
            base.M2();
        }
        public new void M3()
        {
            base.M3();
        }
    }
    class C : A
    {
        public new void M4()
        {
            base.M4();
        }
        public new void M5()
        {
            base.M5();
        }
    }
