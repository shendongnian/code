    [JsonConverter(typeof(JsonSubtypes), "@class")]
    [JsonSubtypes.KnownSubType(typeof(EventA), "some.pkg.EventA")]
    public class EventBase {
    
    }
