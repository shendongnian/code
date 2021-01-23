    [ServiceContract]
    public class OneAndTwoWay
    {
      // The client waits until a response message appears.
      [OperationContract]
      public int MethodOne (int x, out int y)
      {
        y = 34;
        return 0;
      }
      // The client waits until an empty response message appears.
      [OperationContract]
      public void MethodTwo (int x)
      {
        return;
      }
      // The client returns as soon as an outbound message
      // is queued for dispatch to the service; no response
      // message is generated or sent.
      [OperationContract(IsOneWay=true)]
      public void MethodThree (int x)
      {
        return;
      }
    }
