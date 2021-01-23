      public class YourClass {
        // Approved classes (i.e. from your routine) can write, delete, clear... 
        internal List<Data> m_Data = new List<Data>();
    
        // All the other can only read 
        public IReadOnlyList<Data> Data {
          get {
            return m_Data;
          }
        }
        ...
      }
 
