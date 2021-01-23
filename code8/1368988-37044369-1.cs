    string constring = "server=localhost;user=root;pwd=1234;database=test1;";
    string file = "Y:\\backup.sql";
    using (MySqlConnection conn = new MySqlConnection(constring))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                cmd.Connection = conn;
                conn.Open();
                mb.ExportInfo.TablesToBeExportedList = new List<string> {
				    "Table1",
   				    "Table2"
			    };
                mb.ExportToFile(file);
            }
        }
    }
