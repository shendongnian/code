     string propertyName = array[0];
     string propertyValue = array[1];
     Container container = new Container();
     container.PropertyName = propertyName;
     if (int.TryParse(propertyValue, out intVariable))
     {
         container.IntValue = intVariable;
     }
     else if (... ... ...) {}
     else 
     {
         container.StringValue = propertyValue;
     }
     
