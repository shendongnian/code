    //A class with multiple 'set' methods that will silently handle
    //type conversions
    class MyClass{
      private int myValue;
      public int MyValue { { get return this.myValue; } }
      public void SetMyValue(int value){
        this.myValue = value;
      }
      public void SetMyValue(string value){
        this.myValue = Convert.ToInt32(value);
      }
    }
