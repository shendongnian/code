    [JsonObject( IsReference = true, TypeNameHandling = TypeNameHandling.All )]
    [JsonConverter( typeof( ChainNodeConverter ))]
    public abstract class Node
    {
        public List< Node > Children { get; set; }
    }
