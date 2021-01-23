    public class A {
      public class YourGroup {
        // let inner class be creatable by A only
        internal YourGroup() {}
     
        public string test2 {get; set; }
      }
    
      // you have create the group (i.e. class)
      private YourGroup m_Group = new YourGroup();
    
      public string test { get; set; }
    
      public YourGroup folder {
        get {
          return m_Group; 
        }
      }
    }
    
    A a = new A();
    a.test = "";
    a.folder.test2 = "";
