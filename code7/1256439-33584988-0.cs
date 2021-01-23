    Assembly asm = null;
    asm = Assembly.LoadFrom(strProtocolDll);
     Type[] assemblyTypes = asm.GetTypes();
      foreach (Type module in assemblyTypes)
       {
         if (typeof(ProtocolBase) == module.BaseType)
            {
                return (ProtocolBase)Activator.CreateInstance(module);
            }
        }
                        
                                
