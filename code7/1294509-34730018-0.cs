    [Table("ExampleTable")]
    public class ExampleTable
    {
        [NotMapped]
        public DateTime WriteTimestamp
        {
            get
            {
                var db2Tstamp = DB2TimeStamp.Parse(WriteTimestampRaw);
                return db2Tstamp.Value;
            }
            set
            {
                var db2Tstamp = new DB2TimeStamp(value);
                WriteTimestampRaw = db2Tstamp.ToString();
            }
        }
        // This is stored in the DB as a char in the format: 2016-01-11-11.39.53.492000
        [Column("WTIMESTAMP")]
        private string WriteTimestampRaw { get; set; }
    }
