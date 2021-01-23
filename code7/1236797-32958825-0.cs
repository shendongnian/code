    void printPaths()
        {
            string mypath = @"c:\\root\\1";
            string sql = ("select * from paths where pathdesc like @mypath");
            SQLiteCommand command = new SQLiteCommand(sql,m_dbConnection);
            command.Parameters.AddWithValue("@mypath", mypath+"%");
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("ID: " + reader["pathid"] + "\tpathdesc: " + reader["pathdesc"]);
            Console.ReadLine();
        }
