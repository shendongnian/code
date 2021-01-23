      public partial class Test {
        private class TestComparer : IEqualityComparer<Test> {
          public bool Equals(Test x, Test y) { 
            return x.id == y.id && x.date == y.date; 
          }
    
          public int GetHashCode(Test obj) { 
            return obj.id.GetHashCode(); 
          }
        }
    
        // Please, note "static"
        public static IEqualityComparer<Test> MyTestComparer {get;} = new TestComparer();
    
        public int id { get; set; }
        public DateTime date { get; set; }
        ...
      }
