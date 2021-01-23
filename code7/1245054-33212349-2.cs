        public class ProviderIds
        {
            public string ProviderExternalId { get; set; }
        }
    
    
        public class RootObject
        {
        public string Number { get; set; }
        public string ChannelType { get; set; }
        public string ServiceName { get; set; }
        public List<object> ImageInfos { get; set; }
        public bool IsInMixedFolder { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string DateLastSaved { get; set; }
        public List<object> LockedFields { get; set; }
        public string ParentId { get; set; }
        public List<object> Studios { get; set; }
        public List<object> Genres { get; set; }
        public ProviderIds ProviderIds { get; set; }
        }
