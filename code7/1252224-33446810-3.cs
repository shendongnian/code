    public class Book
    {
       public int BookId {get; set;}
       public string title {get; set;}
       public string author {get; set;}
       public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; }
       
       public int UserId { get; set; }
       public virtual User Borrower {get;set;}
    }
    public class BorrwingRecord
    {
        public int BorrowingRecordId {get; set; }
        public DateTime DateBorrowed {get; set;}
        public DateTime DateReturned {get; set;}
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
    public class User
    {
       public int UserId {get;set;}
       public string UserName {get;set;}
       public string Email {get; set;}
       public virtual ICollection<Book> Books {get; set;}
    }
