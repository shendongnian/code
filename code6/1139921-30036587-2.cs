    [DataContract]
    public class RootWrapper<T>
    {
        [DataMember(Name = "Test")]
        public T Test { get; set; }
    }
