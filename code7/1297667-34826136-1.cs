    public class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
            //...
        }
    
        public virtual ICollection<Book> Books {get;set;}
        //... Other properties here
    }
