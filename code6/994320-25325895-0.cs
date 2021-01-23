     public static void CSVToMySQL2()
        {
            string ConnectionString = "server=192.168.1xxx";
            StringBuilder sCommand =  new StringBuilder("INSERT INTO User (FirstName, LastName, BirthDate ) VALUES ");
            string Src = @"C:\myfile.csv";
            char Delimiter = ';';
            char Qualifier = '\"';
            List<string> Rows = new List<string>();
            using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
            {
                mConnection.Open();
                using (StreamReader reader = new StreamReader(Src))
                {
                    string line = null; //Gather CSV-File
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] linesplit = line.Split(new char[] { Delimiter }, StringSplitOptions.None);
                        linesplit = linesplit.Select(x => x.Trim(Qualifier).MySqlEscape()).ToArray();
                        Rows.Add(string.Format("('{0}','{1}','{2}')", linesplit[1], linesplit[2], DateTime.Parse(linesplit[3]).ToString("yyyy-MM-dd")));
                    }
                }
                sCommand.Append(string.Join(",", Rows));
                sCommand.Append(";");
                using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), mConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.ExecuteNonQuery();
                }
            }
        }
