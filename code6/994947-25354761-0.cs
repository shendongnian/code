    try
    {
        //Create a new appdoamin for execute my exe in a isolated way.
        AppDomain sandBox = AppDomain.CreateDomain("sandBox");
        try
        {
            //Exe executing with arguments
            sandBox.ExecuteAssembly(".exe file name with path");
        }
        finally
        {
            AppDomain.Unload(sandBox);//destry created appdomain and memory is released.
        }
    }
    catch (Exception ex)//Any exception that generate from executable can handle
    {
        //Logger.log(ex.Message);
    } 
