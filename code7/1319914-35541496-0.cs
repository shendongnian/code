        public class SqlTraceFile
        {
          public int id { get; set; }
          [Index("IX_SQLTracefile_FileTrace", 1, IsUnique = true)]
          public string Name { get; set; }
          [Index("IX_SQLTracefile_FileTrace", 2, IsUnique = true)]
          public int SqlTraceId { get; set; }
          [ForeignKey("SqlTraceId ")]
          public virtual SqlTrace Trace { get; set; }
       }
   
