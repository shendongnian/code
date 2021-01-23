    try // handle exogenous exceptions
    {  
       try // log all exceptions
       {
           using(var foo = new Foo()) // dispose the resource
           {
               foo.Bar();
           }
       }
       catch(Exception x)
       {
           // All exceptions are logged and re-thrown.
           Log(x);
           throw;
       }
    }
    catch(FooException x) 
    {
        // FooException is caught and handled
    }
