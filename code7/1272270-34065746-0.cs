      public class MyClass {
        private int[] myArray = ...
    
        public IReadOnlyCollection<int> MyArray {
          get {
            return myArray;
          }
        }
      }
