    builder.Register(c => new DatabaseHelper(new SqlFactory()))
           .Named<IDatabaseHelper>("Sql")
           .PropertiesAutowired();
    builder.Register(c => new DatabaseHelper(new OleDbFactory()))
           .Named<IDatabaseHelper>("Oledb")
           .PropertiesAutowired();
