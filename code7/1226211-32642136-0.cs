    using Newtonsoft.Json;
    public class Deliverable
    {
        [JsonProperty(Required = Required.Always)]
        public decimal EstimatedCost { get; private set; }
    }
