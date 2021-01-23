    try
    {
         //Normal code path goes here. Assume appObj is running;
         ObjApp.Quit();
    }
    catch (COMExcpetion exception)
    {
         //Inform the user or log that something has gone wrong.
    }
    finally
    {
        //Clean up you want running no matter what scenario
        Marshal.FinalReleaseComObject(ObjApp);
    }
