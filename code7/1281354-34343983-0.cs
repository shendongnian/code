    [DataContract]
    public abstract class EntityBase<TSubclass> : INotifyPropertyChanged where TSubclass : class
    {
        [DataMember]
        private List<string> _hydratedProperties = new List<string>();
        // More code here
    }
