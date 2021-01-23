    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\MyFolder\Northwind.accdb";
    using( OleDbConnection cnn = new OleDbConnection(connectionString))
    {
        try
        {
            cnn.Open();
            Console.WriteLine("Connection Open!");
            cnn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: Connection Cannot be Opened!");
        }
    }
