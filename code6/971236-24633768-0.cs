    try{
         ...
    }
    catch(ExceptionA a)
    {
       exception = a;  // "Store" the exception in a variable
    }
    catch(Exception e)
    {
        //will not not catch ExceptionA (rethrow or not)
    }
    try
    {
        if (exception)
            throw exception;  // kind of rethrow if variable is set
    }
    catch(ExceptionA a)
    {
        //this would catch the re-throw
    }
    catch( Exception e)
    {
    }
