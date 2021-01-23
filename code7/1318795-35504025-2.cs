      public class MyDefinedList: IList<T> {
        // back ground list that actually stores the data
        private List<T> m_List = new List<T>();
    
        ...
    
        public void Add(T item) {
          m_List.Add(item); // Nothing to write home about
        }
    
        public void DeleteItemFront() {
          m_List.RemoveAt(0);
        } 
    
        ...
      }
