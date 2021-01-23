    public class Example
    {
       private MyCustomClass _data;
       
       public MyCustomClass Data
       { 
          get
          {
             if(_data == null)
               _data = new MyCustomClass();
             return _data;
          }
          private set { _data = value;} }             
    }
