    public class SampleContextMemento
    {
        private readonly SampleContext context;
        private readonly IEnumerable<Person> addedPeople;
        private readonly IEnumerable<Person> deletedPeople;
        private IEnumerable<T> GetEntitiesByState<T>(EntityState state)
            where T : class
        {
            return context.ChangeTracker
                .Entries<T>()
                .Where(_ => _.State == state)
                .Select(_ => _.Entity)
                .ToList();
        }
        public SampleContextMemento(SampleContext context)
        {
            this.context = context;
            addedPeople = GetEntitiesByState<Person>(EntityState.Added);
            deletedPeople = GetEntitiesByState<Person>(EntityState.Deleted);
        }
        public void Rollback()
        {
            // delete added entities
            foreach (var item in addedPeople)
            {
                context.People.Remove(context.People.Find(item.Id));                
            }
            
            // add deleted entities
            foreach (var item in deletedPeople)
            {
                context.People.Add(item);
            }
            // save reverted changes
            context.SaveChanges();
        }
    }
