    [DataContract]
    class Machine
    {
        [DataMember]
        [JsonProperty("id ")]
        internal string id { get; set; }
    
        [DataMember]
        [JsonProperty("guid ")]
        internal string guid { get; set; }
    
        [DataMember]
        [JsonProperty("name")]
        internal string name { get; set; }
    }
    public class MachineJson
    {
        [JsonProperty("machine")]
        public Machine Machine{ get; set; }
    }
    var machine = JsonConvert.DeserializeObject<List<MachineJson>>(json);
