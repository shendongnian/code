    class Message
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
