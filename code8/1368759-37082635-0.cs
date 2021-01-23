    [ServiceContract]
    interface IAdderWcfContract
    {
        //
        // Adds the input to the value stored in the service and returns the result.
        //
        [OperationContract]
        Task<double> AddValue(double input);
        //
        // Resets the value stored in the service to zero.
        //
        [OperationContract]
        Task ResetValue();
        //
        // Reads the currently stored value.
        //
        [OperationContract]
        Task<double> ReadValue();
    }
    class MyService: StatefulService, IAdderWcfContract
    {
        ...
        CreateServiceReplicaListeners()
        {
            return new[] { new ServiceReplicaListener((context) =>
                new WcfCommunicationListener<IAdderWcfContract>(
                    wcfServiceObject:this,
                    serviceContext:context,
                    //
                    // The name of the endpoint configured in the ServiceManifest under the Endpoints section
                    // that identifies the endpoint that the WCF ServiceHost should listen on.
                    //
                    endpointResourceName: "WcfServiceEndpoint",
                    //
                    // Populate the binding information that you want the service to use.
                    //
                    listenerBinding: WcfUtility.CreateTcpListenerBinding()
                )
            )};
        } 
        
        // implement service methods
        ...
    }
