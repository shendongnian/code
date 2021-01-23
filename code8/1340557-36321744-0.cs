    eSBFault = Microsoft.Practices.ESB.ExceptionHandling.ExceptionMgmt.CreateFaultMessage();
    eSBFault.FailureCategory= "General System Exception";
    eSBFault.FaultCode = "500";
    eSBFault.FaultDescription = orchestrationName + ": " + SystemException.Message;
    eSBFault.FaultSeverity = Microsoft.Practices.ESB.ExceptionHandling.FaultSeverity.Error;
    eSBFault.Scope = "Scope Name";   
    Microsoft.Practices.ESB.ExceptionHandling.ExceptionMgmt.AddMessage(eSBFault, InputMsg);
