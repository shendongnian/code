    public class Book
    {
       public int Id {get; set;}
       public string title {get; set;}
       public string author {get; set;}
       public int BorrowingRecordId { get; set; }
       public virtual BorrowingRecord BorrowingRecord { get; set; }
       // followed by whatever else you want or had
    }
    public class BorrwingRecord
    {
        public int Id {get; set; }
        public DateTime DateBorrowed {get; set;}
        public DateTime DateReturned {get; set;}
        public virtual ICollection<Book> Books { get; set; }
    }
