    public class Context : DbContext
    {
        private readonly ObjectContext m_ObjectContext;
        public DbSet<Person> People { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public Context()
        {
            var m_ObjectContext = ((IObjectContextAdapter)this).ObjectContext;
            m_ObjectContext.ObjectMaterialized += context_ObjectMaterialized;
        }
        void context_ObjectMaterialized(object sender, System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {
            var person = e.Entity as Person;
            if (person == null)
                return;
            if (person.Profile == null)
                person.Profile = new Profile() {Person = person};
        }
    }
