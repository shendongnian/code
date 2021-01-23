    class RoyalMailIEndpointBehavior: IOperationBehavior {
      public RoyalMailIEndpointBehavior() {}
      public void ApplyClientBehavior(OperationDescription description, ClientOperation proxy) {
        IClientMessageFormatter currentFormatter = proxy.Formatter;
        proxy.Formatter = new RoyalMailMessageFormatter(currentFormatter);
      }
      public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters) {
      }
      public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation) {
      }
      public void Validate(OperationDescription operationDescription) {
      }
    }
