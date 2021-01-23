    [DebuggerDisplay("{Kind}: {Identifier}")]
    public class SocialConnection
    {
        public virtual Guid UniqueId
        {
            get { return Id; }
            set { Id = value; }
        }
    
        // SocialConnectionKind is an enumeration
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public virtual SocialConnectionKind Kind { get; set; }
    
        public virtual string Identifier { get; set; }
    }
