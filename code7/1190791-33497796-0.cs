    try 
    {
       var csv = new CsvReader(new StreamReader(path));
    }
    catch (UnauthorizedAccessException e)
    {
       //handle it
    }
    catch (System.Exception e)
    {
       //handle it
    }
