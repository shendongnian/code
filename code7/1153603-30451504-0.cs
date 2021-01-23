    public DataSet LoadSearchDataSet(string strConnection, string strSQL)
    {
        //The purpose of this function is to create and populate a data
        //set based on a SQL statement passed in to the function.
        DataSet dsData = new DataSet();
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
    }
