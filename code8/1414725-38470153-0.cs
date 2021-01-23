    public class Book
    { 
        [Key]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Author{ get; set; }
    
        public ICollection<BookReviews> Reviews { get; set; }
    
    }
