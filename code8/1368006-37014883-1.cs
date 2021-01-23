    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class A : List<B>
    {
        [JsonProperty]
        public double TestA { get; set; }
    
        [JsonProperty]
        public B[] Items
        {
            get
            {
                return this.ToArray();
            }
            set
            {
                if (value != null)
                    this.AddRange(value);
            }
        }
    }
    
    public class B
    {
        public double TestB { get; set; }
    }
