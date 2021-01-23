    // Method has generic parameter <T> and returns result of type T:
    private T ReadClassFromXml<T>( string code)  
    {
      object myObject = FindObject<T>( code );
    
      if ( myObject == null )
      {
        myObject = CreateObject<T>( );
        myType.GetProperty("Code").SetValue(myObject, code, null);
      }
    
      return myObject;
    }
