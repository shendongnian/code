    static Type GetTransactionType(string transactionType, int version)
    {
        string key = transactionType + version;
    
        if (!typeCache.ContainsKey(key))
        {
            var configuration = GetConfiguration(transactionType, version);
    
            Type dynamicType = DynamicClassHelper.CompileResultType(transactionType + version, configuration.Fields);
    
            typeCache.Add(key, dynamicType);
        }
    
        return typeCache[key];
    }
