    public class A {} //why we even need this class?
    public class B : A, I3Methods
    {
        public void Method1() { }
        public void Method2() { }   
        public void Method3() { }
    }
    
    public class C : A, I2Methods
    {
        public void Method4() { }
        public void Method5() { }
    }
    public interface I3Methods
    {
        void Method1();
        void Method2();
        void Method3();
    }
    
    public interface I2Methods
    {
        void Method4();
        void Method5();
    }
