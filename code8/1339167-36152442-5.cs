      //TODO: you may want to implement IEnumerable<Item>
      public class MyClass {
        private List<Item> m_Items = new List<Item>();
    
        private void Expand(int index) {
          if (index < 0) 
            throw new ArgumentOutOfRangeException("index");
    
          for (int i = m_Items.Count; i <= index; ++i)
            m_Items.Add(new Item());
        }
    
        // indexer: mimics auto expanding array
        public Item this[int index] {
          get {
            Expand(index); 
    
            return m_Items[index];
          }
        } 
        public int Count {
          get {
            return m_Items.Count;
          }  
        }
      }
...
  
      MyClass test = new MyClass();
      // test will be expanded to have 1 item: test[0]
      test[0].y = 456;
      // test will be expanded to have 6 items [0..5]
      test[5].x = 123; 
