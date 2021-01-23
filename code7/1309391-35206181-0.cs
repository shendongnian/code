    public class OrganisationRepository : IOrganisationRepository
    {
        public Func<IOrganisationDomainDbContext> ContextFactory { get; set; }
    
        public Organisation GetDetailByIdentifier(int id)
        {
            var context = ContextFactory.Invoke()
            var org = context.Organisations.SingleOrDefault(x => x.Id == id);
            return org;
        }
    
        public void Create(Organisation orgToCreate)
        {
            var context = ContextFactory.Invoke();
            context.Organisations.Add(orgToCreate);
            context.SaveChanges();
        }
    }
