    try
    {
      //access service code in this try block
    }
    catch (FaultException e)
    {
    	Console.WriteLine("{0}: {1}", e.Code.Name, e.Reason); //catch fault exception here
    }
