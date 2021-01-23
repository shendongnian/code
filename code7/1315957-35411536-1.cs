    Datatable newTable = FillTable("SELECT * FROM MyOldTable");
    using (MySqlBulkCopy destination = new MySqlBulkCopy("MyNewDatabaseConnection String"))
    {
        destination.DestinationTableName = "myNewTable";
        try
        {
            destination.WriteToServer(newTable);
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.Message);
        }
    }
