    static async Task Example()
    {
        string connectionString =
            "Server=mydomainname.com;" +
            "Port=3306;" +
            "Database=scratch;" +
            "Uid=Assassinbeast;" +
            "Password=mypass123;" +
            "AllowUserVariables= true;";
    
        MySql.Data.MySqlClient.MySqlConnection sqConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        await sqConnection.OpenAsync();
    
        Console.Write("Opened. Now Click to close");
        Console.ReadLine();
    
        sqConnection.Close();
    }
    static void Main(string[] args)
    {
        Console.ReadLine();
        Task.Run(() => Example()).Wait();
        Console.WriteLine("Done");
        Console.ReadLine();
    }
