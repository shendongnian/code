    public class A
    {
        private void MethodA()
        {
        }
        public class B
        {
            private void MethodB()
            {
                A a = new A();
                a.MethodA();
            }
        }
    }
    public class C
    {
        private void MethodC()
        {
            //MethodA is not accessible here
        }
    }
    public class D : A
    {
        private void MethodC()
        {
            //MethodA is not accessible here
        }
    }
 
