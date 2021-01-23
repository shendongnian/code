    public class UserRecord
    {
        /* other properties */
        // Let's assume that Book is the class which has the AuthorID property
        public virtual ICollection<Book> Books { get; set; }
    }
