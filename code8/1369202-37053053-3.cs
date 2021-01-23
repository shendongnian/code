    try
    {
         //Normal code path goes here. Assume appObj is running;
         ObjApp.Quit();
    }
    //optinal catch clauses here
    finally
    {
        //Clean up you want running no matter what scenario
        Marshal.FinalReleaseComObject(ObjApp);
    }
