    private void RemoveOperationsFromPortTypes(ServiceDescription wsdl, out List<string> messageNamesToRemove)
    {
        messageNamesToRemove = new List<string>();
        var emptyPorts = new List<System.Web.Services.Description.PortType>();
        foreach (System.Web.Services.Description.PortType portType in wsdl.PortTypes)
        {
            for (int i = portType.Operations.Count - 1; i >= 0; i--)
            {
                ...
    
                if (portType.Operations.Count == 0)
                    emptyPorts.Add(portType);
            }
        }
    
        foreach (var emptyPort in emptyPorts)
        {
            wsdl.PortTypes.Remove(emptyPort);
        }
    }
    
    private void RemoveOperationsFromBindings(ServiceDescription wsdl, out List<string> policiesToRemove)
    {
        policiesToRemove = new List<string>();
        var emptyBindings = new List<System.Web.Services.Description.Binding>();
        foreach (System.Web.Services.Description.Binding binding in wsdl.Bindings)
        {
            for (int i = binding.Operations.Count - 1; i >= 0; i--)
            {
                ...
            }
    
            if (binding.Operations.Count == 0)
                emptyBindings.Add(binding);
        }
    
        foreach (var emptyBinding in emptyBindings)
        {
            wsdl.Bindings.Remove(emptyBinding);
        }
    }
