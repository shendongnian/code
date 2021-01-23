    public class Borrowed {
        [Key]
        public int BorrowID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; } 
        // Navigation Properties
        public virtual LibUser User { get; set; }
        public virtual Book Book { get; set; }
    }
    Borrows.Where(borrow => borrow.UserId == 2)
           .Select(borrow => borrow.Book);
