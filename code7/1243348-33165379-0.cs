    public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
                dispatchOperation.ParameterInspectors.Add(this);
            }
    
            public object BeforeCall(string operationName, object[] inputs)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Forbidden;
                throw new WebFaultException<string>("Unauthorized", HttpStatusCode.Forbidden);
            }
