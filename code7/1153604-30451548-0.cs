        DataSet dsData = null;
        try
                {
                    //call the table in the local dataset "results" since the values
                    //may be coming from multiple tables.
                    string strTableName = "Results";
                    bool blnRunStoredProc = false;
                    dsData = PopulateDataSetTable(strConnection, strTableName, strSQL, blnRunStoredProc, dsData);
        
                    WriteSampleDataToOutputWindow(dsData);
                }
                catch
                {
                    //error handling goes here
                    UnhandledExceptionHandler();
                }
    //return the data set to the calling procedure
                    return dsData;
