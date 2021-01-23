    public class MyContext : DbContext
    {
        public MyContext()
            : base("MyContextConnectionString")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.AutoDetectChangesEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Parent>();
            modelBuilder.Entity<Child>();
        }
    }
    public class Parent
    {
        public int Id { get; set; }
        public string NameParent { get; set; }
        public static Parent Create(int id)
        {
            return new Parent { Id = id };
        }
    }
    public class Child
    {
        private Parent theOnlyParent;
        private int theOnlyParentId;
        public int Id { get; set; }
        public string NameChild { get; set; }
        [Required]
        public Parent TheOnlyParent
        {
            get
            {
                return theOnlyParent;
            }
            set
            {
                theOnlyParent = value;
                if (value != null)
                    TheOnlyParentId = value.Id;
            }
        }
        public int TheOnlyParentId  
        {
            get { return theOnlyParentId; }
            set { 
                theOnlyParentId = value;
                theOnlyParent = Parent.Create(value);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start create database");
            Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
            Console.WriteLine("Start adding Parent");
            var p1 = new Parent {NameParent = "Test Parent Name#1"};
            int parentCreatedId;
            Console.WriteLine("Context");
            using (var context = new MyContext())
            {
                context.Set<Parent>().Add(p1);
                context.SaveChanges();
                parentCreatedId = p1.Id;
            }
            Console.WriteLine("Start adding a child from a different context");
            var c1 = new Child { NameChild= "Child #1" };
            c1.TheOnlyParentId = parentCreatedId;
            c1.TheOnlyParent = new Parent {Id = parentCreatedId};
        
            Console.WriteLine("Context");
            using (var context = new MyContext())
            {
                Console.WriteLine("*Change State Child");
                context.Entry(c1).State = EntityState.Added; // Conflicting changes to the role 'Child_TheOnlyParent_Target' of the relationship 'Child_TheOnlyParent' have been detected.
                Console.WriteLine("*Change State Child->Parent Navigability Property");
                context.Entry(c1.TheOnlyParent).State = EntityState.Unchanged; // We do not want to create but reuse
                Console.WriteLine("*Save Changes");
                context.SaveChanges();
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
