    public class Foo {
        public void SetSomeValue(int someParam) {
    		if (this is ISomeValueHolder) {
    			((ISomeValueHolder)this).SomeValue = someParam;
    		}
        }
    }
    
    public interface ISomeValueHolder {
    	int SomeValue { get; set; }
    }
    
    public class Bar : Foo, ISomeValueHolder {
        public int SomeValue { get; set; }
    }
