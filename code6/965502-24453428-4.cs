    using System;
    using System.Collections.Generic;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Configuration;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    
    namespace Nelibur.ServiceModel.Behaviors
    {
        /// <summary>
        ///     Provides CORS support.
        /// </summary>
        public class EnableCrossOriginResourceSharingBehavior : BehaviorExtensionElement, IEndpointBehavior
        {
            /// <summary>
            ///     Gets the type of behavior.
            /// </summary>
            /// <returns>
            ///     A <see cref="T:System.Type" />.
            /// </returns>
            public override Type BehaviorType
            {
                get { return typeof (EnableCrossOriginResourceSharingBehavior); }
            }
    
            /// <summary>
            ///     Implement to pass data at runtime to bindings to support custom behavior.
            /// </summary>
            /// <param name="endpoint">The endpoint to modify.</param>
            /// <param name="bindingParameters">The objects that binding elements require to support the behavior.</param>
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
    
            /// <summary>
            ///     Implements a modification or extension of the client across an endpoint.
            /// </summary>
            /// <param name="endpoint">The endpoint that is to be customized.</param>
            /// <param name="clientRuntime">The client runtime to be customized.</param>
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
            }
    
            /// <summary>
            ///     Implements a modification or extension of the service across an endpoint.
            /// </summary>
            /// <param name="endpoint">The endpoint that exposes the contract.</param>
            /// <param name="endpointDispatcher">The endpoint dispatcher to be modified or extended.</param>
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                var requiredHeaders = new Dictionary<string, string>();
    
                requiredHeaders.Add("Access-Control-Allow-Origin", "*");
                requiredHeaders.Add("Access-Control-Request-Method", "POST,GET,OPTIONS");
                requiredHeaders.Add("Access-Control-Allow-Headers", "X-Requested-With,Content-Type");
    
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CustomHeaderMessageInspector(requiredHeaders));
            }
    
            /// <summary>
            ///     Implement to confirm that the endpoint meets some intended criteria.
            /// </summary>
            /// <param name="endpoint">The endpoint to validate.</param>
            public void Validate(ServiceEndpoint endpoint)
            {
            }
    
            /// <summary>
            ///     Creates a behavior extension based on the current configuration settings.
            /// </summary>
            /// <returns>
            ///     The behavior extension.
            /// </returns>
            protected override object CreateBehavior()
            {
                return new EnableCrossOriginResourceSharingBehavior();
            }
        }
    }
