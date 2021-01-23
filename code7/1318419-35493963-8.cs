    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string LogContent { get; set; }
        public string TableName { get; set; }
        public DateTime LogDate { get; set; }
        public string BlameName { get; set; }
        public bool? Deleted { get; set; }
    }
