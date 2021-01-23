    public static class SQL
    {
        public const string Customers = @"SELECT * FROM Customers";
    }
    //Wherever you're going to use it
    new MySqlCommand(SQL.Customers);
