    public class Tree<T> {
        public Tree<T> Left, Right;
        public T value;
        public IEnumerable<T> InOrder() {
          if(Left != null) {
            foreach(T val in Left.InOrder())
              yield return val;
          }
          yield return value;
          if(Right != null) {
            foreach(T val in Right.InOrder())
              yield return val;
          }
        }
      }
    }
