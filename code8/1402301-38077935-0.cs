    try
    {
         //Call Path here you will get to what the exactly error is
    }
    catch (Exception ex)
    {
         if (ex is DirectoryNotFoundException|| ex is IOException|| ex is SecurityException)
         {
              //Your handling here
         }
         else
         {
              throw;
         }
    }
