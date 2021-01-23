      _container = new UnityContainer();
      _container.RegisterType<IBook, Book>();
      if (useDatabase)
      {
          _container.RegisterType<IBookRepository, DatabaseRepository>();
      }
      else
      {
          _container.RegisterType<IBookRepository, BookRepository>();
      }
      _container.RegisterType<IBookService, BookService>();
