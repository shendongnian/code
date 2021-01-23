    public class Composite: Element
    {
       ...
       [JsonProperty("Elements")]
       private List<Element> Elements { get; set; }
       ...
    }
