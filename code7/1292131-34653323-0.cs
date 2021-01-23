    public class Test<T> {
        public void Set(T item) {
            this.item = item;
            this.OnSet(item);
            abc();
        }
        protected virtual void OnSet(T item) { }
    }
    
    public class IntTest : Test<int> {
        protected override void OnSet(int item) { ... }
    }
    
    public class StringTest : Test<string> { 
        protected override void OnSet(string item) { ... }
    }
