    public class Contacts
    {
        private IContactsRepository repo;
        public Contacts(IContactsRepository injectedContactsRepository)
        {
            repo = injectedContactsRepository;
        }
        public Contact Get(long id)
        {
            var contact = repo.Get(id);
            return contact;
        }
    //and other methods definitions...
    }
