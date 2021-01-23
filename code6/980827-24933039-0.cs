    try
    {
      proxy.SomeOperation();
    }
    catch (FaultException<MyFaultInfo> ex)
    {
      // only if a fault contract was specified
    }
    catch (FaultException ex)
    {
      // any other faults
    }
    catch (CommunicationException ex)
    {
      // any communication errors?
    }
