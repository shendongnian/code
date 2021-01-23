    public class ExampleClass {
      //Properties - one is not visible to the class calling the constructor
      public string Property1 { get; set; }
      string Property2 { get; set; }
       //Constructor
       public ExampleClass(string property1, string property2)
      {
         this.Property1 = property1;
         this.Property2 = property2;  //this caused that error for me
      }
    }
