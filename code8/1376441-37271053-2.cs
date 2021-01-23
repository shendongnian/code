      // We usually start classes with capital letter
      class Football {
        private int m_Weight;
        // C# is not Java, so use properties, which are more readable
        public int Weight {
          get {
            return m_Weight;
          }
          private set {
            // validate input
            if (value <= 0)
              throw new ArgumentOutOfRangeException("value"); 
            m_Weight = value;  
          }
        }
        
        // "weight" - let argument correspond to property
        public football(int weight) {
          Weight = weight;
        }
      }
