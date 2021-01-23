      public class Sample {
        private int m_Data;
    
        // property (and "get") is public - anyone can read the property
        public int Data {
          get { // "get" has "public" modifier as property does
            return m_Data; 
          }
          internal set { // "set" is internal - caller should be in the same assembly 
            m_Data = value;
          }
        }
      }
