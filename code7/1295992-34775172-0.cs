    private static byte[] computeHash<T>(object instance, T cryptoServiceProvider) where T : HashAlgorithm, new()
    {
        // Original Code using DataContractSerializer throws an Exception.
        //DataContractSerializer serializer = new DataContractSerializer(instance.GetType());
        // Use the following instead of the above in order to avoid Exception being thrown.
        NetDataContractSerializer serializer = new NetDataContractSerializer();
        using (MemoryStream memoryStream = new MemoryStream())
        {
            serializer.WriteObject(memoryStream, instance);
            cryptoServiceProvider.ComputeHash(memoryStream.ToArray());
            return cryptoServiceProvider.Hash;
        }
    }
