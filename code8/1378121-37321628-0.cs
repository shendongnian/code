    public interface Condition<Expected> {
      // you can't declare interface method as public or, say, private: 
      // it's the implementing class that provides the access modifier
      bool verify(Expected expected, object actual);
    }
    
    public class Equals : Condition<object> {   
      public bool verify(object expected, object actual) {
        return expected == actual || (expected != null && expected.Equals(actual));
      }
    }
