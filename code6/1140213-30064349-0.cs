    // Making it type safe
    public interface IExtendableOf<T> : IExtendable where T : class, IExtendable 
    {
        IExtensionDataFor<T> ExtensionData { get; set; }
    }
    // Making it type safe & discoverable through reflection.
    public interface IExtensionDataFor<T> : IExtensionData where T : class
    {
    }
