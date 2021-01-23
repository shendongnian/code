    var exceptionList = new List<ExceptionLines>();
    try
    {
        // read lines, parse...
    }
    catch(Exception ex)
    {
        // handle the lines with the exception. Add the exception and the necessary arguments to the collection
        exceptionList.Add( new ExceptionLines(....));
    }
    // do stuff
    // handle the exceptions.
    foreach(var exception in exceptionList)
    {
        try
        {
            // process the exception line.
        }
        catch(Exception ex)
        {
              // log error and handle exception
        }
    }
