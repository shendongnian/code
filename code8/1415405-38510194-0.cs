    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Dapper;
    namespace MyApp.Models
    {
        [Table("Clients", Schema="Products")]
        public class Client
        {
            public int id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
        }
    }
