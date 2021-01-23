     public class Program
     {
         public static void Main(string[] args)
         {
             Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
    
             using (var myDbContext = new MyDbContext("DefaultConnection"))
             {
                 var a1 = new A();
                 var a2 = new A();
    
                 var b1 = new B
                 {
                     Child1 = a1,
                     Child2 = a2
                 };
    
                 myDbContext.Bs.Add(b1);
                 myDbContext.SaveChanges();
             }
    
             using (var myDbContext = new MyDbContext("DefaultConnection"))
             {
                 var b1 = myDbContext.Bs.FirstOrDefault();
                 b1.ToString();
                 Console.WriteLine(b1.ToString());
             }
         }
    
         public class A
         {
             public int AId { get; set; }
         }
    
         public class B
         {
             public int BId { get; set; }
             public virtual A Child1 { get; set; }
             public virtual A Child2 { get; set; }
         }
    
         public class MyDbContext : DbContext
         {
             public DbSet<A> As { get; set; }
             public DbSet<B> Bs { get; set; }
    
             protected override void OnModelCreating(DbModelBuilder modelBuilder)
             {
                 modelBuilder.Entity<B>()
                     .HasRequired(x => x.Child1)
                     .WithMany()
                     .Map(x => x.MapKey("Child1Id")).WillCascadeOnDelete(false);
    
                 modelBuilder.Entity<B>()
                     .HasRequired(x => x.Child2)
                     .WithMany()
                     .Map(x => x.MapKey("Child2Id")).WillCascadeOnDelete(false);
    
                 base.OnModelCreating(modelBuilder);
             }
    
             public MyDbContext(string connectionString)
               : base("name=" + connectionString)
             {
                 this.Configuration.LazyLoadingEnabled = true;
                 this.Configuration.ProxyCreationEnabled = true;
             }
         }
     }
