     class Node<T>: IEnumerable<Node<T>> {
       ...
        public IEnumerator<Node<T>> GetEnumerator() {
          return children.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
          return GetEnumerator();
        }
     }
