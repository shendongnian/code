     class Program
        {
            static void Main(string[] args)
            {
                using (var db = new aaContext2())
                {
                    IList<DTO> dto = new List<DTO>();
                    dto = db.Table2.Select(a => new DTO
                    {
                        Name = a.Name,
                        User = a.Namea.User,
                        DateDifference = (DbFunctions.DiffDays(a.Date, db.Table2.Where(aa => aa.Name.Equals(a.Name) && a.Date < aa.Date).Min(dd => dd.Date)
                        ) ?? (DbFunctions.DiffDays(db.Table1.Where(aa => aa.Name.Equals(a.Name)).Min(aaa => aaa.Date), a.Date)))
                    }).ToList();
                }
            }
        }
        public class DTO
        {
            public string User { get; set; }
            public string Name { get; set; }
            public int? DateDifference { get; set; }
        }
        public class aaContext2 : DbContext
        {
            public DbSet<Table1> Table1 { get; set; }
            public DbSet<Table2> Table2 { get; set; }
    
        }
        public class Table1
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual IList<Table2> NameList { get; set; }
    
            public DateTime Date { get; set; }
            public string User { get; set; }
    
        }
        public class Table2
        {
            public int Id { get; set; }
            public virtual Table1 Namea { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }
    
    }
