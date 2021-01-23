    var typeString = "System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
    
    var typeName = GetTypeName(typeString);
    
    switch(typeName)
    {
       case "System.Int32":
          //code to convert the dynamic representation into an int (e.g. Int32.TryParse(theTypeAsString) );
          break;
       case "System.Double":
          //code to convert the dynamic representation into an double (e.g. Double.TryParse(theTypeAsString) );
          break;
       ...
       default:
          throw new InvalidOperationException("The type provided is unknown.");
    }
