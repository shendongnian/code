    public void db1_read()
        {
            if (con_opened == false)
            {
                con = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");//Version=3;
                con_opened = true;
                con.Open();
            }
            string sql = "select * from bestscore WHERE materie LIKE 'literatura'";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            bs_lit = Int32.Parse(reader[1].ToString());
            command.Dispose();
            reader.Dispose();
            sql = "select * from bestscore WHERE materie LIKE 'informatica'";
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            bs_info = Int32.Parse(rdr[1].ToString());
            cmd.Dispose();
            rdr.Dispose();
            
            con.Close();
            con_opened = false;
        }    
