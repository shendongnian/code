    [Table(Name = "ClassA")]
    public class ClassA
    {
        public ClassA()
        {
            LinksToClassB = new EntitySet<ClassB>();
        }
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int ID;
        [Association(ThisKey = "ID", OtherKey = "ClassAId")]
        private EntitySet<ClassB> LinksToClassB;//=> 1 to n cardinality
        
        public void addLink(ClassB x)
        {
            LinksToClassB.Add(x);
            x.setLink(this);
        }
        public HashSet<ClassB> getLinks()
        {
            HashSet<ClassB> collection = new HashSet<ClassB>();
            foreach(ClassB x in LinksToClassB)
            {
                collection.Add(x);
            }
            return collection;
        }
    }
    [Table(Name = "ClassB")]
    public class ClassB
    {
        private EntityRef<ClassA> _classA = default(EntityRef<ClassA>);
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY")]
        public int ID { get; set; }
        [Column(CanBeNull = true)]
        public string Name { get; set; }
        [Column(CanBeNull = false)]
        private int ClassAId { get; set; }
        [Association(ThisKey = "ClassAId", OtherKey = "ID", IsForeignKey = true)]
        private ClassA ClassA
        {
            get
            {
                return _classA.Entity;
            }
            set
            {
                _classA.Entity = value;
            }
        }
        private ClassA getLink()
        {
            return _classA.Entity;
        }
        public void setLink(ClassA x)
        {
            _classA.Entity = x;
        }
    }
    public class DatabaseContext : DataContext
    {
        public Table<ClassA> ClassATable;
        public Table<ClassB> ClassBTable;
        public DatabaseContext(string connection) : base(connection) { }
    }
    [TestClass]
    public class Test
    {
        string path = @"F:\Temp\Testspace - Forum Database\database.mdf";//path to database
        [TestMethod]
        public void TestMethod()
        {
            //creates Database
            DatabaseContext context = new DatabaseContext(path);
            if (context.DatabaseExists())//Delete if exists
            {
                context.DeleteDatabase();
            }
            context.CreateDatabase();
            ClassB b1 = new ClassB(); b1.Name = "name 1";
            ClassB b2 = new ClassB(); b2.Name = "name 2";
            ClassB b3 = new ClassB(); b3.Name = "name 3";
            ClassA a = new ClassA();
            //now the references will be added to the object a
            //in 1-n references
            a.addLink(b1);
            a.addLink(b2);
            a.addLink(b3);
            context.ClassATable.InsertOnSubmit(a);
            context.SubmitChanges(); //store in database
            //now the database will be reloaded
            context = new DatabaseContext(path);
            //Check if all ClassB objects were correctly stored and reloaded
            foreach (ClassB x in context.ClassBTable)
            {
                Console.WriteLine(x.ID + "; " + x.Name);
                /*    
                    -> expected output:
                        1; name 1
                        2; name 2
                        3; name 3
                    -> real output
                        1; name 1
                        2; name 2
                        3; name 3
                    -> check!
                */
            }
            //check if all ClassA objects were correctly stored and reloaded
            foreach (ClassA x in context.ClassATable)//context.ClassATable has only one entry
            {
                Console.WriteLine("check of entitys set");
                //check of 1-n references
                foreach (ClassB b in x.getLinks())
                {
                    Console.WriteLine(b.ID + " has a link to " + b.ID + ", " + b.Name);
                    /*
                        -> expected output:
                            1 has a link to 1, name 1
                            1 has a link to 2, name 2
                            1 has a link to 3, name 3
                        -> real output
                            1 has a link to 1, name 1
                            1 has a link to 2, name 2
                            1 has a link to 3, name 3
                        -> check!
                    */
                }
            }
        }
    }
