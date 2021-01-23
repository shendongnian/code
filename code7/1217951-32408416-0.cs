    public interface IMyClass {
        int Test();
    }
    
    class MyClass1 : IMyClass {
        public virtual int Test() {
            int val = 1;
            val += 100;
            return val;
        }
    }
    
    class MyClass2 {
        public override int Test() {
            return 2*base.Test()
        }
    }
