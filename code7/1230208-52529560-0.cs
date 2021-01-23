    class MyClass
    {
      public string StringKey = "";
      public int IntKey = 0;
    
      public override Equals(object obj)
      {
        // Code to return true if all fields are equal
      }
    }
    
    Dictionary <MyClass, string> MyDict;
    MyClass myClass;
    
    MyDict[MyDict.Keys.FirstOrDefault(x => x.Equals(MyClass))];
