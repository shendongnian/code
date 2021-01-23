    [Table(Name = "ClassA")]
    public class ClassA
    {
        public ClassA()
        {
            LinksToClassB = new EntitySet<ClassB>();
        }
    
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY")]
        public int ID { get; set; }
    
        [Association(ThisKey="ID", OtherKey="ClassAId")]
        public EntitySet<ClassB> LinksToClassB { get; set; } //=> 1 to n cardinality
    
        [Association]
        public ClassB OneLinkToClassB { get; set; }//=> 1 to 1 cardinality
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
        public int ClassAId { get; set; }
    
        [Association(ThisKey = "ClassAId", OtherKey = "ID", IsForeignKey = true)]
        public ClassA ClassA {
            get
            {
                return _classA.Entity;
            }
            set {
                // property changed implementation omitted for brevity...
                _classA.Entity = value;
            } 
        }
    }
