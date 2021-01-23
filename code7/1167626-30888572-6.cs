    try
    {
      	//access service code in this try block
    }
    catch (FaultException<DatabaseFault> df)
    {
    	Console.WriteLine("DatabaseFault {0}: {1}\n{2}", df.Detail.DbOperation, df.Detail.DbMessage, df.Detail.DbReason);
    }
    catch (FaultException e)
    {
    	Console.WriteLine("{0}: {1}", e.Code.Name, e.Reason);
    }
