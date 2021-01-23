     System.Exception thrownException = null;
     try{
            ...
       }
       catch( ExceptionA a)
       {
          thrownException = a;
          ...  // do special handling...
       }
       catch( ExceptionA b)
       {
          thrownException = b;
          ...  // do special handling...
       }
       catch(Exception e)
       {
          ...
       }
       finally{
         if ( thrownException != null ) {
              ...   //case the type here or use some other way to identify..
         }
       }
