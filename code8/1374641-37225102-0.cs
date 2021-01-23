    public class WrappedEntities
    {
        private MyEntityFramework Entities = new MyEntityFramework();
        //regular public entities
        public DbSet<Organisation> Organisations { get { return Entities.Organisation; } set { Entities.Organisation = value as DbSet<Organisation>; } }
        //Special case
        public IQueryable<User> Users(int id)
        {
            return Entities.Users.Where(x => x.OrganisationId == organisationId);
        }
        //other wrapped methods...
        public int SaveChanges()
        {
            return Entities.SaveChanges();
        }
    }
