    class Book {
        ...
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
