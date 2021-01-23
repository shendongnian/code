    class MyValue
    {
      public string ID { get; set; }
      public string prop1 { get; set; }
      public string prop2 { get; set; }
      public int Value { get; set; }
    
      public static List<MyValue> Get()
      { 
        //create a list of MyValues and return it
        return new List<MyValue>();
      }
    }
