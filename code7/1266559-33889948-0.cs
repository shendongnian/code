      public class MyClass {
        // class itself can modify m_MyList 
        private IList<int> m_MyList = new List{1, 2, 3};
        ...
        // ... while code outside can't  
        public IReadOnlyList<int> MyList {
          get {
            return m_MyList; 
          }
        }  
      }
