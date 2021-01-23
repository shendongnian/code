    string connectionString = 
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
        System.IO.Path.Combine(
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().GetName().CodeBase), 
            "MyDatabase.mdf") + 
        @";Integrated Security = True;"
