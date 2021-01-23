    static void CreateAndSeedDatabase()
    {
        Context context = new Context();
        ReferencedClass anotherClass1 = new ReferencedClass(){Name="instance1"};
        ReferencedClass anotherClass2 = new ReferencedClass() { Name = "instance2" };
        ComplexTypeClass complexType1 = new ComplexTypeClass(){ReferencedClassProp = anotherClass1};
        ComplexTypeClass complexType2 = new ComplexTypeClass() { ReferencedClassProp = anotherClass2 };
        Parent parent1 = new Parent() { ComplexTypeClassProp = complexType1 };
        Parent parent2 = new Parent() { ComplexTypeClassProp = complexType2 };
        context.Parents.Add(parent1);
        context.Parents.Add(parent2);
        context.SaveChanges();
    }
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseAlways<Context>());
            Database.Initialize(true);
        }
        public DbSet<Parent> Parents { get; set; }
    }
    public class Parent
    {
        public int Id { get; set; }
        public ComplexTypeClass ComplexTypeClassProp { get; set; }
    }
    [ComplexType]
    public class ComplexTypeClass
    {
        public ReferencedClass ReferencedClassProp { get; set; }
    }
    public class ReferencedClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
