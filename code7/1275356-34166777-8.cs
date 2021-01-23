    public class LeaseInstrument
    {
        [JsonConverter(typeof(IgnoreCollectionTypeConverter), typeof(OwnerToLeaseOwnerConverter))]
        public ObservableCollection<LeaseOwner> OriginalLessees { get; set; }
    }
