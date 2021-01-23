    public interface IEntity
    {
    }
    public class Address : IEntity
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
    public class Client : IEntity
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
    public class GenericRepo<T> where T : class, IEntity
    {
        private ClientsDbContext context;
        public GenericRepo(ClientsDbContext context)
        {
            this.context = context;
        }
        public virtual void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public virtual void Add(T entity) => context.Set<T>().Add(entity);
        public virtual T Get(int id) => context.Set<T>().Find(id);
        public virtual void SaveContext() => context.SaveChanges();
    }
    static void Main(string[] args)
    {
        var clientRepo = new GenericRepo<Client>(new ClientsDbContext());
        var client = new Client { Addresses = new List<Address> { new Address { Street = "some street" } }, Name = "ClienName" };
        clientRepo.Add(client);
        clientRepo.SaveContext();
        // than update already existing entity, by adding new addresses
        var dbClient = clientRepo.Get(client.ClientId);
        dbClient.Addresses.Add(new Address { Street = "New street 1" });
        dbClient.Addresses.Add(new Address { Street = "New street 2" });
        clientRepo.Update(client);
    }
