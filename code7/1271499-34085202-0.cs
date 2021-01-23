    public void ExportEndpoint(WsdlExporter exporter, WsdlEndpointConversionContext context)
    {
        foreach (ServiceDescription wsdl in exporter.GeneratedWsdlDocuments)
        {
            List<string> messageNamesToRemove;
            RemoveOperationsFromPortTypes(wsdl, out messageNamesToRemove);
    
            List<string> policiesToRemove;
            RemoveOperationsFromBindings(wsdl, out policiesToRemove);
    
            RemoveWsdlMessages(wsdl, messageNamesToRemove);
            RemoveOperationRelatedPolicies(wsdl, policiesToRemove);
        }
    }
