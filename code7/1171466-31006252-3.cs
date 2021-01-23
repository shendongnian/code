    public class Team
    {
        public string Group { get; set; }
        public string Leader { get; set; }
        public string Email { get; set; }
        public string Month { get; set; }
        public override string ToString()
        {
            return String.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n", Group, Leader, Email, Month);
        }
    }
