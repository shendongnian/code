    public class Release
    {
        public Release()
        {
        }
    
        public Release(int Id, string Name, string Type, string Slug)
        {
            this.id = Id;
            this.name = Name;
            this.type = Type;
            this.slug = Slug;
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string slug { get; set; }
    }
