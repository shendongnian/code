    public class A
    {
        protected void MethodA()
        {
        }
    }
    public class B : A
    {
        private void MethodB()
        {
            //MethodA is accessible just here
        }
    }
    public class C
    {
        private void MethodC()
        {
            //MethodA is not accessible here
        }
    }
