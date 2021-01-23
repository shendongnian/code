      class MyPair {
        public string NameA { get; internal set; }
        public string NameB { get; internal set; }
    
        public MyPair(nameA, nameB) {
          NameA = nameA;
          NameB = nameB;  
        }
        public override String ToString() {
          return $"NameA = {NameA}; NameB = {NameB}";
        }
      }
    
      class Other {
        // you don't want "set" here
        // = new ... <- C# 6.0 feature
        public Dictionary<string, MyPair> Data { get; } = new Dictionary<string, MyPair>() {
          {"key", new MyPair("something", "something else")},
        };
    
       ...
    
     Other myOther = new Other();
    
     String test = myOther.Data["key"].NameA;
