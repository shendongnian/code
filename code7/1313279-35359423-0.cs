    public class RegUser
    {
        [ForeignKey(typeof(User))]
        public int UserID { get; set; }
        [ForeignKey(typeof(Register))]
        public int RegisterID { get; set; }
        public string Status { get; set; }
    }
