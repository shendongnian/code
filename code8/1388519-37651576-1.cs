    public class BaseClass 
    {
        protected void H1B(int a, int b, int c, int d) { ... }
    }
    public class BaseClassFor3 : BaseClass
    {
        public void H1(int a, int b, int c) { H1B(a,b,c,0); } // forward call
    }
    public class C1 : BaseClassFor3 {} // etc
    public class C2 : BaseClassFor3 {} // etc 
    public class C3 : BaseClassFor3 {} // etc
    public class C4 : BaseClass
    {
        public void H1(int a, int b, int c, int d) { H1B(a,b,c,d); } // forward call
    }
