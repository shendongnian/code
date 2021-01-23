    class Movie {
        [PrimaryKey]
        [MaxLength(255)
        public string Title {get; set;}
        public datetime ReleaseDate {get; set;}
        public float Price {get; set;} // Or the type you prefere
    }
