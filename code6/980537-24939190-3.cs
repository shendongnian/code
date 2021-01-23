        using System;
        using System.ServiceModel;
        using System.ServiceModel.Description;
        using System.Runtime.Serialization;
        using System.Xml;
        using System.Collections.Generic;
    
        [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Method)]
        public class CyclicReferencesAwareAttribute : Attribute, IContractBehavior, IOperationBehavior
        {
            private readonly bool _on = true;
    
            public CyclicReferencesAwareAttribute(bool on)
            {
                _on = on;
            }
    
            public bool On
            {
                get { return _on; }
            }
    
            #region IOperationBehavior Members
    
            void IOperationBehavior.AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
            }
    
            void IOperationBehavior.ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
            {
                CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehavior(operationDescription, On);
            }
    
            void IOperationBehavior.ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
            {
                CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehavior(operationDescription, On);
            }
    
            void IOperationBehavior.Validate(OperationDescription operationDescription)
            {
            }
    
            #endregion
    
            #region IContractBehavior Members
    
            void IContractBehavior.AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
            }
    
            void IContractBehavior.ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
            {
                CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehaviors(contractDescription, On);
            }
    
            void IContractBehavior.ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
            {
                CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehaviors(contractDescription, On);
            }
    
            void IContractBehavior.Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
            {
            }
    
            #endregion
        }
    
        public class CyclicReferencesAwareContractBehavior : IContractBehavior
        {
            private const int MaxItemsInObjectGraph = 2147483647;
            private const bool IgnoreExtensionDataObject = false;
    
            private bool _on;
    
            public CyclicReferencesAwareContractBehavior(bool on)
            {
                _on = on;
            }
    
            #region IContractBehavior Members
    
            public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
            {
                ReplaceDataContractSerializerOperationBehaviors(contractDescription, _on);
            }
    
            public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
            {
                ReplaceDataContractSerializerOperationBehaviors(contractDescription, _on);
            }
    
            public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
            {
            }
    
            internal static void ReplaceDataContractSerializerOperationBehaviors(ContractDescription contractDescription, bool on)
            {
                foreach (var operation in contractDescription.Operations)
                {
                    ReplaceDataContractSerializerOperationBehavior(operation, on);
                }
            }
    
            internal static void ReplaceDataContractSerializerOperationBehavior(OperationDescription operation, bool on)
            {
                if (operation.Behaviors.Remove(typeof(DataContractSerializerOperationBehavior)) || operation.Behaviors.Remove(typeof(ApplyCyclicDataContractSerializerOperationBehavior)))
                {
                    operation.Behaviors.Add(new ApplyCyclicDataContractSerializerOperationBehavior(operation, MaxItemsInObjectGraph, IgnoreExtensionDataObject, on));
                }
            }
            #endregion
        }
    
        internal class ApplyCyclicDataContractSerializerOperationBehavior : DataContractSerializerOperationBehavior
        {
            private readonly int _maxItemsInObjectGraph;
            private readonly bool _ignoreExtensionDataObject;
            private readonly bool _preserveObjectReferences;
    
            public ApplyCyclicDataContractSerializerOperationBehavior(OperationDescription operationDescription, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, bool preserveObjectReferences)
                : base(operationDescription)
            {
                _maxItemsInObjectGraph = maxItemsInObjectGraph;
                _ignoreExtensionDataObject = ignoreExtensionDataObject;
                _preserveObjectReferences = preserveObjectReferences;
            }
    
            public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
            {
                return new DataContractSerializer(type, name, ns, knownTypes, _maxItemsInObjectGraph, _ignoreExtensionDataObject, _preserveObjectReferences, null /*dataContractSurrogate*/);
            }
    
            public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
            {
                return new DataContractSerializer(type, name, ns, knownTypes, _maxItemsInObjectGraph, _ignoreExtensionDataObject, _preserveObjectReferences, null /*dataContractSurrogate*/);
            }
        }
