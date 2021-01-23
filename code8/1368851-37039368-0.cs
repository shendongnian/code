    public class Notice
    {
        public int UserId { get; set; }
    
        public bool ShouldSerializeUserId ()
        {
            return // your condition;
        }
    
        public string Login { get; set; }
    
        public bool ShouldSerializeLogin  ()
        {
            return // your condition;
        }
    
        public string Message { get;set; }
    }
