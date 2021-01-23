    public interface IFoo {
        void foo();
    }
    public class ChildOne : ParentClass, IFoo {
        public new void foo() {
            Debug.Log("Child one called!");
        }
    }
    public class ChildTwo : ParentClass, IFoo {
        public new void foo() {
            Debug.Log("Child two called!");
        }
    }
