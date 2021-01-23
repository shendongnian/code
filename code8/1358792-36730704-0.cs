    namespace ConsoleApplication1
    {
        class Db : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Batch> Batches { get; set; }
        }
    
        class User
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            public virtual List<Batch> Batches { get; set; }
        }
    
        class Batch
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int BatchId { get; set; }
            [Required, MaxLength(256)]
            public string Key { get; set; }
            [MaxLength(512)]
            public string Value { get; set; }
            public virtual List<Batch> Children { get; set; }
        }
    
        class Initializer : DropCreateDatabaseAlways<Db>
        {
            protected override void Seed(Db context)
            {
                var user = new User();
                context.Users.Add(user);
                user.Batches = new List<Batch>();
                user.Batches.AddRange(new List<Batch>
                {
                    new Batch {Key = "First Name", Value = "John"},
                    new Batch {Key = "Last Name", Value = "Smith"},
                    new Batch {Key = "Passport", Children = new List<Batch>
                    {
                        new Batch {Key = "Issued", Value = "2014-02-03"},
                        new Batch {Key = "Expired", Value = "2015-02-03"},
                    }}
                });
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Database.SetInitializer(new Initializer());
                using (var db = new Db())
                {
                    Console.WriteLine(JsonConvert.SerializeObject(db.Batches.ToList(), Formatting.Indented));
                    Console.ReadLine();
                }
            }
        }
    }
