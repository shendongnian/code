    public class MyDBContextSeeder : DropCreateDatabaseIfModelChanges<MyDBContext>
        {
            protected override void Seed(MyDBContext context)
            {
                IList<Dog> defaultDog = new List<Dog>();
                defaultDog.Add(new Dog("Spike"));
        
                foreach (Dog d in defaultDog)
                    context.Dogs.Add(d);
        
                context.SaveChanges();
            }
        }
--
    public class MyDBContext : DbContext
    {
        static MyDBContext()
        {
            Database.SetInitializer<MyDBContext>(new MyDBContextSeeder());
        }
    }
