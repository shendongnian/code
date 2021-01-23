    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    namespace ASDMVC.Models
    {
        [Table("Log")]
        public class LogModel
        {
            [Key]
            public long id { get; set; }
            public string message { get; set; }
            public DateTime timeStamp { get; set; }
            public string level { get; set; }
            public int customerId { get; set; }
            [NotMapped]
            public string Name { get; set; }
        }
    
        public class LogDBContext:DbContext
        {
            public LogDBContext() : base("MySqlConnection")
            {
    
            }
    
            public DbSet <LogModel> Log { get; set; }
    
            public IQueryable<LogModel> GetLogs()
            {
                return from log in Log
                       select log;
            }
        }
    }
