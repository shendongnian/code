    public IEnumerable<object> GetServices(Type serviceType)
    {
        //Code is the same because our container only have an object for each Type
        object result = null;
        try
        {
            MethodInfo serviceProviderGetMethod =
                m_serviceProvider.GetType().GetMethod("Get").MakeGenericMethod(new Type[] { serviceType });
            result = serviceProviderGetMethod.Invoke(m_serviceProvider, null);
        }
        catch (Exception)
        {
        }
        
        if(resul == null)
        {
           return new List<object>();
        }
        return (IEnumerable<object>) result;
    }
