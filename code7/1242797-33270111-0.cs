    [Serializable]
    [KnownType(typeof(RemoteProcessHandle))]
    public sealed class RemoteLaunchServiceResult<T>
    {
        // I solved the problem by adding the "KnownType" attribute. I thought
        // it would have worked having it in the "RemoteLaunchService" class,
        // but I was wrong!
    }
