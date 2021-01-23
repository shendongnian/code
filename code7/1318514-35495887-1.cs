    try
    {
      dir.Delete(true);
    } 
    catch(Exception x)
    {
      if (x is UnauthorizedAccessException || x is IOException){
        Console.WriteLine("Error Removing the directory: {0}", dir.FullName);
      }
      else throw;
    } 
