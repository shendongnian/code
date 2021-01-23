    public class Book
    {
        [JsonIgnore]
        public Person Author { get; private set; } // we need setter to deserialize
        [JsonProperty("author")]
        private string AuthorName // can be private
        {
            get { return Author?.Name; } // null check
            set { Author = new Author { Name = value }; }
        }
    }
