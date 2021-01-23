    private T FindObject<T>( string code )
    {
      T myObject = FindObject<T>( code );
    
      if ( myObject == null )
      {
        myObject = CreateObject<T>( );
        myObject.Code = code;
      }
    
      return myObject;
    }
