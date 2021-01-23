    public class Test 
    {
        [Key(Order=0)]
        public int UserId { get; set; }
        [Key(Order=1)]
        public int BookId { get; set; }
        public User User { get; set; }
 
        public Book Book { get; set; }
    }
