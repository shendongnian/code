    [NotMapped]
    public object TypedValue
    {
        get 
        { 
           switch(Type)
           {
              case "int":
                 return int.Parse(Value); // parse to whatever needed, with a switch
              // ...
           }
        }
        set
        {
          switch(value.GetType)
          {
              case typeof(int):
                 Value = // formatted int
                 break;
              // ...
          }
        }
    }
