    [JsonObject( IsReference = true )]
    [JsonConverter( typeof( ChainNodeConverter ))]
    public abstract class Node
    {
    }
