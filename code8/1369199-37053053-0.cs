    try
    {
         //Normal clean up code goes here. Assume appObj is running;
         app
    }
    catch (COMExcpetion exception)
    {
         //Inform the user or log that something has gone wrong.
         ObjApp.Quit();
    }
    finally
    {
        //Clean up you want running no matter what
        Marshal.FinalReleaseComObject(ObjApp);
    }
