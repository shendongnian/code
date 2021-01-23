    public List<IServiceInterface> CreateShippingInstance(string assemblyInfo)
    {
        Type[] assemblyType = Type.GetTypeArray(assemblyInfo);
        if (assemblyType != null)
        {
            List<IServiceInterface> serviceClientList = new List<IServiceInterface>();
            Type[] argTypes = new Type[] { };
    
            foreach(var item in argTypes)
            {
               ConstructorInfo cInfo = assemblyType.GetConstructor(argTypes);
    
               IServiceInterface serviceClient = (IServiceInterface)cInfo.Invoke(null);
               if(serviceClient!=null)
               serviceClientList.Add(serviceClient);
            } 
    
            return serviceClientList;
        }
        return null;       
    }
