    public class MyOperation : Attribute, IOperationBehavior
        {
            public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
            {
            }
    
            public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
    
                MyMessageInspector inspector = dispatchOperation.Parent.MessageInspectors
                    .Where(x => x is MyMessageInspector)
                    .FirstOrDefault() as MyMessageInspector;
    
                if (inspector != null)
                {
                    inspector.AddOperation(operationDescription);
                }
                else
                {
                    inspector = new MessageInspectors(operationDescription);
                    dispatchOperation.Parent.MessageInspectors.Add(inspector);
                }
            }
    
            public void Validate(OperationDescription operationDescription)
            {
            }
        }
