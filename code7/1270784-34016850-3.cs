      public class YourClass {
        // Approved classes (i.e. from your routine) can write, delete, clear... 
        internal readonly List<Data> m_Data = new List<Data>();
    
        // All the other can only read 
        public IReadOnlyList<Data> Data {
          get {
            return m_Data;
          }
        }
        ...
        // If you let (in some cases) add, delete, clear to untrusted class 
        // just add appropriate methods:
        public void Add(Data data) {
          // Here you can validate the provided data, check conditions, state etc.
        }
      }
 
