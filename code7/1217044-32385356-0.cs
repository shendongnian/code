    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class EmptyActionBehaviorAttribute : Attribute, IContractBehavior
    {
        public void AddBindingParameters(
            ContractDescription contractDescription, 
            ServiceEndpoint endpoint, 
            BindingParameterCollection bindingParameters)
        {
            return;
        }
        public void ApplyClientBehavior(
            ContractDescription contractDescription, 
            ServiceEndpoint endpoint, 
            ClientRuntime clientRuntime)
        {
            return;
        }
        public void ApplyDispatchBehavior(
            ContractDescription contractDescription, 
            ServiceEndpoint endpoint, 
            DispatchRuntime dispatchRuntime)
        {
            var dispatchDictionary = new Dictionary<XmlQualifiedName, string>();
            foreach (var operationDescription in contractDescription.Operations)
            {
                var qname = new XmlQualifiedName(
                    operationDescription.Messages[0].Body.WrapperName, 
                    operationDescription.Messages[0].Body.WrapperNamespace);
                dispatchDictionary.Add(qname, operationDescription.Name);
            }
            dispatchRuntime.OperationSelector 
                = new EmptyActionOperationSelector(dispatchDictionary);
        }
        public void Validate(
            ContractDescription contractDescription, 
            ServiceEndpoint endpoint)
        {
        }
    }
