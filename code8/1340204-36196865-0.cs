    class Foo : FooBase {
      Lazy<IDbRepository> _db;
      public Foo(Settings settings, Lazy<IDbRepository> db)
        : base(settings) {
        _db = db;
      }
    }
