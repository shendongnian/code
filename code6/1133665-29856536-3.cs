    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    namespace Ef6Test {
    public class Program {
        public static void Main(string[] args) {
            ExecDb1();
       
        }
        private static void ExecDb1() {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Ef6Ctx, Ef6MigConf>());
            WhichDb.DbName = "MSAMPLEDB";
            WhichDb.ConnType = ConnType.CtxViaDbConn;
            var sqlConn = GetSqlConn4DBName(WhichDb.DbName);
            var context = new Ef6Ctx(sqlConn);
            context.Database.Initialize(true);
            Console.WriteLine(WhichDb.DbName, context.Database.Exists() );
            AddJunk(context);
         
        }
        
        public static class WhichDb {
            public static string DbName { get; set; }
            public static string ConnectionName { get; set; }
            public static ConnType ConnType { get; set; }
        }
        public enum ConnType {
            CtxViaDbConn,
            CtxViaConnectionName
        }
        private static void AddJunk(DbContext context) {
            var friend = new Friend();
            friend.Name = "Fred";
            friend.Phone = "555-1232424";
            context.Set<Friend>().Add(friend);
            context.SaveChanges();
            // break here and check db content.
            var eg = new Example();
            eg.Best = friend;  // set them equal
            eg.Oldest = friend;
            friend.Name = "Fredie"; // change the name of the fly
            friend.Phone = "555-99999"; // and phone is also different
            context.Set<Example>().Add(eg); Add the new example
            context.SaveChanges();
  
            // result... 2 records.
            // The original friend record should be chnaged
        }
        public static DbConnection GetSqlConn4DBName(string dbName) {
            var sqlConnFact = new SqlConnectionFactory(
                "Data Source=localhost; Integrated Security=True; MultipleActiveResultSets=True");
            var sqlConn = sqlConnFact.CreateConnection(dbName);
            return sqlConn;
        }
    }
    public class MigrationsContextFactory : IDbContextFactory<Ef6Ctx> {
        public Ef6Ctx Create() {
            switch (Program.WhichDb.ConnType) {
                case Program.ConnType.CtxViaDbConn:
                    var sqlConn = Program.GetSqlConn4DBName(Program.WhichDb.DbName); //
                    return new Ef6Ctx(sqlConn);
                case Program.ConnType.CtxViaConnectionName:
                    return new Ef6Ctx(Program.WhichDb.ConnectionName);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class Ef6MigConf : DbMigrationsConfiguration<Ef6Ctx> {
        public Ef6MigConf() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
   
    public class Friend {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        
    }
    public class Example
    {
        public int Id { get; set; }
        public int? BestFriendId { get; set; }
        public int? OldestFriendId { get; set; }
        public virtual Friend Best { get; set; }
        public virtual Friend Oldest { get; set; }
        
     }
       public class Ef6Ctx : DbContext {
        public Ef6Ctx(DbConnection dbConn) : base(dbConn, true) { }
        public Ef6Ctx(string connectionName) : base(connectionName) { }
        public DbSet<Friend> Friends { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Example>()
                        .HasOptional(t=>t.Best)
                        .WithMany()
                        .HasForeignKey(x=>x.BestFriendId);
            modelBuilder.Entity<Example>()
                        .HasOptional(t => t.Oldest)
                        .WithMany()
                        .HasForeignKey(x => x.OldestFriendId);
            }
     }
    
    }
