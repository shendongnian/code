    public class MyClass
    {
      private string _otherValue;
      public string ModelId {get; set;}
      public string OtherValue 
      {
        get 
        {
          return this._otherValue;  
        }
        set
        {
          switch(value){
            case "UP" :
              _otherValue = "pathToImage";
              break;
            case "DOWN" :
              _otherValue = "pathToImage2";
              break;
            // etc...
          }
        }
      }    
    }
