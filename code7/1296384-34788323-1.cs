    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<Book> DBBooks { get; set; }
        public DbSet<Shelf> DBShelves { get; set; }
     
        private IBookRepository _bookRepository;
        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(this);
                return _bookRepository;
            }
        }
        private IShelfRepository _shelfRepository;
        public IShelfRepository ShelfRepository
        {
            get
            {
                if (_shelfRepository == null)
                    _shelfRepository = new ShelfRepository(this);
                return _shelfRepository;
            }
        }
     
        public UnitOfWork() : base("Name=MyDB") { }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // If you use fluent syntax mapping, initialize those here
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new ShelfMap());
        }
     
        public void Commit()
        {
            SaveChanges();
        }
    }
