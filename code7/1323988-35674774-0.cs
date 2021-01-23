    Class1
    {
      public ExampleInstance Instance { get; set; }
      //Create your Class2 object here with Class2 SecondClassObject = new Class2(this)
    }
    
    Class2
    {
      private Class1 MyCreator;
      public Class2(Class1 Creator)
      {
        this.MyCreator = Creator;
      }
      //Now you can use the object with: MyCreator.Instance
    }
