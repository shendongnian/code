    public class BaseRepository
    {
        protected readonly DbContext _dbContext;
        //...
        public BaseRepository(DbContext context)
        {
            _dbContext = context;
        }
        //...
    }
    public class ContactsRepository : BaseEFRepository<Contact, long>, IContactsRepository
    {
        //...
        public ContactsRepository(DbContext context)
            :base(context)
        {
        }
        //...
    }
    public class Contacts
    {
        private readonly IContactsRepository m_ContactsRepository;
        
        public Contacts(IContactsRepository contacts_repository)
        {
            m_ContactsRepository = contacts_repository;
        }
        public Contact Get(long id)
        {
            var contact = m_ContactsRepository.Get(id);
            return contact;
        }
        //...
    }
