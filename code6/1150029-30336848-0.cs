    public class EntityHeader
    {
        int Id { get; set; }
        int Checksum { get; set; }
    }
    
    public class Entity
    {
        private EntityHeader m_Header = new EntityHeader();
        public EntityHeader Header { get { return m_Header; } }
    
        [JsonProperty]
        private int Id { set { m_Header.Id = value; } }
        [JsonProperty]
        private int Checksum { set { m_Header.Checksum = value; } }
    
        public string Name { get; set; }
    
        public bool Hair { get; set; }
    }
