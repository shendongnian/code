    public class FormData
    {
        public string audience { get; set; }
        public Calendar[] calendar { get; set; }
    
        public FormData()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    
        public class Calendar
        {
            public int qtrNumber { get; set; }
            public string qtrString { get; set; }
            public int[] qtrTools { get; set; }
            public int qtrYear { get; set; }
        }
    }
