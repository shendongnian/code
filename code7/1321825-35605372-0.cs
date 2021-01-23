    con.Open();
            MySqlDataAdapter dt = new MySqlDataAdapter();
            DataTable tt = new DataTable();            
            string query = @"SET @rank=0; 
               SELECT player_ID,player_name,HP
               FROM player_profile ORDER BY HP DESC;";
            MySqlCommand cm1 = new MySqlCommand(query, con);
            dt.SelectCommand = cm1;
            dt.Fill(tt);            
            con.Close();
            DataRow[] foundRows = tt.Select("player_name=" + Label2.Text); // Error:Cannot find column ["Column name"]
            int count = 1;
            foreach (DataRow dr in foundRows)
            {
                Label32.Text = count;//dr["Rank"].ToString();
                count++;
            }
