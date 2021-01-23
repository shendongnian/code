    public class ContactsRepositoryWithUow : IRepository<Contact>
    {
        private SampleDbEntities entities = null;
    
        public ContactsRepositoryWithUow(SampleDbEntities _entities)
        {
            entities = _entities;
        }
    
        public IEnumerable<Contact> GetAll(Func<Contact, bool> predicate = null)
        {
            if (predicate != null)
            {
                if (predicate != null)
                {
                    return entities.Contacts.Where(predicate);
                }
            }
    
            return entities.Contacts;
        }
    
        public Contact Get(Func<Contact, bool> predicate)
        {
            return entities.Contacts.FirstOrDefault(predicate);
        }
    
        public void Add(Contact entity)
        {
            entities.Contacts.AddObject(entity);
        }
    
        public void Attach(Contact entity)
        {
            entities.Contacts.Attach(entity);
            entities.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
    
        public void Delete(Contact entity)
        {
            entities.Contacts.DeleteObject(entity);
        }       
    }
