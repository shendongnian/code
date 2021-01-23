    public class Maintenance
    {
        public int PersonId { get; set; }
        [JsonExtensionData]
        public Dictionary<string, dynamic> ThisNameWillNotBeInTheJson { get; set; }
    }
