     [JsonObject(MemberSerialization = MemberSerialization.Fields)]
        public class DrivenList : List<int>
        {
            
            [JsonProperty]
            public string Name { get; set; }
    
            private DrivenList() { }
    
            public DrivenList(string name) { this.Name = name; }
        }
