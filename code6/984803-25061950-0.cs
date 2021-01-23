        [DataContract(Namespace = "")]
        public class Plan
        {
            [DataMember(Order = 0)]
            public string Id { get; set; }
    
            [DataMember(Order = 1)]
            public List<Zone> Zones { get; set; }
    
            public Plan()
            {
                this.Id = string.Empty;
                this.Zones = new List<Zone>();
            }
        }
    
        [DataContract(Namespace = "")]
        public class Zone
        {
            [DataMember(Order = 0)]
            public string Id { get; set; }
    
            public Zone()
            {
                this.Id = string.Empty;
            }
        }
