    public Rule026(/*otherArgs*/, IServiceProviderFactory scpFactory = null) {
        if(null == scpFactory)
            scpFactory = new ServiceProviderFactory();
        }
        _serviceProviderFactory = scpFactory;
    }
