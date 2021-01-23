    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var db = new ConsoleApplication10.DBContext())
                {
                    var list= db.Database.SqlQuery<DbResult>("SELECT display_name, country_code FROM dbo.mytable").ToList();
                }
            }
        }
        class DbResult
        {
            public string display_name { get; set; }
            public string country_code { get; set; }
        }
    }
