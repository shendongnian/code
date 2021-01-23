    if (requestMsgSet != null)
    {
        Marshal.FinalReleaseComObject(requestMsgSet);
    }
    if (invoiceQueryRq != null)
    {
        Marshal.FinalReleaseComObject(invoiceQueryRq);
    }
    sessionMgr.EndSession();
    sessionMgr.CloseConnection();
