    void buttonFunction(object obj)
    {
       switch(obj.ToString())
       {
          case "a": 
             MyPropertyA = Visibility.Hidden;
             MyPropertyB = Visibility.Visible;
             break;
          case "b": 
             MyPropertyB = Visibility.Hidden;
             break;
             ....
       }
       ....
    }
