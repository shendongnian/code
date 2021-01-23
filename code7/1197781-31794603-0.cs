    class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var anime = obj as Anime;
            if (anime == null) return false;
            return this.Id == anime.Id;
        }
    }
