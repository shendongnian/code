    //excention method (in some static class)
    public static ServiceInfo GetServiceByGuid (
       this ConcurrentDictionary<CollectionInfo, ServiceInfo> dic, Guid id){
       ServiceInfo si;
       dic.TryGetValue(new CollectionInfo() { InstanceId = id}, out si);
       return si;
    }
