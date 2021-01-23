    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Database2.MDB;System Database=C:\Data\SYSTEM.MDW;User ID=Developer;Password=Password";
    string commandText = "INSERT INTO [TableName] In 'C:\\Data\Database1.mdb' SELECT * FROM [TableName]";
    try
    {
        using (OleDbConnection oleConnection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand oleCommand = new OleDbCommand(commandText, oleConnection))
            {
                oleCommand.CommandType = CommandType.Text;
                oleCommand.Connection.Open();
                oleCommand.ExecuteNonQuery();      
            }
        }
    }
    catch (Exception)
    {
        throw;
    }
