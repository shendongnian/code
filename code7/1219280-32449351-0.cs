    static void UnityRegister()
    {
        _container = new UnityContainer();
        _container.RegisterType<IBook, Book>();
        _container.RegisterType<IBookRepository, BookRepository>();            
        _container.RegisterType<IBookRepository, DatabaseRepository>();
        _container.RegisterType<IBookService, BookService>("BookService", new InjectionConstructor(typeof(BookRepository)));
        _container.RegisterType<IBookService, BookService>("DatabaseService", new InjectionConstructor(typeof(DatabaseRepository)));
    }
