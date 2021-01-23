    public class Entity
    {
        public int Id;
        public string EntityName;
        
        [JsonProperty(PropertyName = "Items")]
        private List<Entity> _items;
    
        //Sub entities
        public IReadOnlyList<Entity> Items
        {
            get { return _items; }
        }
    }
