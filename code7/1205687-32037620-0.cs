    using Newtonsoft.Json;
    class Post {
    
        public int Id { get; set; }
    
        public string Title  { get; set; }
    
        public string Content { get; set; }
        
        [JsonIgnore]
        public User User { get; set; } // This property won't be serialized
    } 
