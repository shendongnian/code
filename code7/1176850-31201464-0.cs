    if (mWorkBook != null)
    {
        mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
    }
    if (oXL != null)
    {
        oXL.Quit();
        if (mWSheet1 != null)
        {
            Marshal.FinalReleaseComObject(mWSheet1);
            mWSheet1 = null;
        }
        if (mWorkSheets != null)
        {
            Marshal.FinalReleaseComObject(mWorkSheets);
            mWorkSheets = null;
        }
        if (mWorkBook != null)
        {
            Marshal.FinalReleaseComObject(mWorkBook);
            mWorkBook = null;
        }
        Marshal.FinalReleaseComObject(oXL);
        oXL = null;
    }
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
    GC.WaitForPendingFinalizers();
