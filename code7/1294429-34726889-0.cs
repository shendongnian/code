    using System.Data.Odbc;
    using(OleDbConnection connection = new OleDbConnection(con))
    {
        connection.Open();
        OleDbCommand command = new OleDbCommand("SELECT * from TestTable", connection) 
        using(OleDbDataReader reader = command.ExecuteReader())
        {
             while(reader.Read())
             {
                Console.Write(reader[0].ToString() + ", ");
                Console.Write(reader[1].ToString() + ", ");
                Console.Write(reader[2].ToString() + ", ");
                Console.Write(reader[3].ToString() + ", ");
                Console.WriteLine(reader[4].ToString());
             }
        }
    }
