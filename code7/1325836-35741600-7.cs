    public class SampleContextMemento
    {
        private IEnumerable<Person> addedPeople;
        private IEnumerable<Person> deletedPeople;
    
        private IEnumerable<T> GetEntitiesByState<T>(SampleContext context, EntityState state)
            where T : class
        {
            return context.ChangeTracker
                .Entries<T>()
                .Where(_ => _.State == state)
                .Select(_ => _.Entity)
                .ToList();
        }
    
        public void RecordChanges(SampleContext context)
        {
            addedPeople = GetEntitiesByState<Person>(context, EntityState.Added);
            deletedPeople = GetEntitiesByState<Person>(context, EntityState.Deleted);
        }
    
        public void RollbackChanges(SampleContext context)
        {
            // delete added entities
            if (addedPeople != null)
            {
                foreach (var item in addedPeople)
                {
                    context.People.Remove(context.People.Find(item.Id));
                }
            }
    
            if (deletedPeople != null)
            {
                // add deleted entities
                foreach (var item in deletedPeople)
                {
                    context.People.Add(item);
                }
            }
    
            // save reverted changes
            context.SaveChanges();
        }
    }
