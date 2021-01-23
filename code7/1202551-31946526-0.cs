    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication6
    {
        class DatabaseAccessor
        {
            static async void Main(string[] args)
            {
                await Task.Run(() =>
                {
                    InquireDatabaseAsync.LongRunningOperation();
                });
            }
        }
    
        public static class InquireDatabaseAsync
        {
            public static void LongRunningOperation()
            {
                Data_connection2 dbobject = new Data_connection2();
                SQLiteConnection m_dbConnection = new SQLiteConnection();
                m_dbConnection.ConnectionString = dbobject.datalocation2();
                m_dbConnection.Open();
    
                string sql = "SELECT * FROM Commands WHERE Id = (SELECT MAX(Id) FROM Commands)";
                SQLiteCommand SQLcommand = new SQLiteCommand(sql, m_dbConnection);
    
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                        Console.WriteLine("Id: " + reader["Id"] + "\tInstruction: " + reader["Instruction"] + "\tCellular: " + reader["Cellular"] + "\tTimestamp: " + reader["Timestamp"]);
                    break;
                }
                Console.WriteLine("Finished.");
            }
        }
    
        class Data_connection2
        {
            public string datalocation2()
            {
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return "Data Source=" + dir + "\\database9.sqlite";
            }
        }
    }
