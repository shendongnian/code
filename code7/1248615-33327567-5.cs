            using (SqlConnection con = new SqlConnection(constr))
            {
                string SelectCommand = "select Genre,Name,Artist, Price from Music WHERE Name = '" + Name + "' ";
                SqlCommand cmd = new SqlCommand(SelectCommand, con);
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Music.Genre = read.GetString(0);
                        Music.Name = read.GetString(1);
                        Music.Artist = read.GetString(2);
                        Music.Price = read.GetDecimal(3);
                        listMusic.Items.Add(Music.Genre + " : " + Music.Artist + " - " + Music.Name + " $" + Music.Price);
                    }
                }
            }
