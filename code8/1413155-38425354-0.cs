    public static void AddSong(Songs s)
        {
            using (SqlConnection sqlcon = new SqlConnection(SQL_getConnectionString.conStr()))
            {
                sqlcon.Open();
                try
                {
                    string query = "INSERT INTO Songs VALUES(@Id, @Name, @Artist, @Album, @TrackNumber, @TrackNumberCount, " +
                        "@Genre, @Rating, @Tags, @Subject, @Categories, @Comments, @FileName, @FolderName, @FolderPath, " +
                        "@FullPath, @Length, @PlayCount, @SkipCount, @LastPlayed)";
                    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = s.Id;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 250).Value = s.Name;
                        cmd.Parameters.Add("@Album", SqlDbType.VarChar, 250).Value = s.Album;
                        cmd.Parameters.Add("@Artist", SqlDbType.VarChar, 250).Value = s.Artist;
                        cmd.Parameters.Add("@TrackNumber", SqlDbType.Int).Value = s.TrackNumber;
                        cmd.Parameters.Add("@TrackNumberCount", SqlDbType.Int).Value = s.TrackNumberCount;
                        cmd.Parameters.Add("@Genre", SqlDbType.VarChar, 500).Value = s.Genre;
                        cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = s.Rating;
                        cmd.Parameters.Add("@Tags", SqlDbType.VarChar, 500).Value = s.Tags;
                        cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 500).Value = s.Subject;
                        cmd.Parameters.Add("@Categories", SqlDbType.VarChar, 500).Value = s.Categories;
                        cmd.Parameters.Add("@Comments", SqlDbType.VarChar, -1).Value = s.Comments;
                        cmd.Parameters.Add("@FileName", SqlDbType.VarChar, 500).Value = s.FileName;
                        cmd.Parameters.Add("@FolderName", SqlDbType.VarChar, 500).Value = s.FolderName;
                        cmd.Parameters.Add("@FolderPath", SqlDbType.VarChar, -1).Value = s.FolderPath;
                        cmd.Parameters.Add("@FullPath", SqlDbType.VarChar, -1).Value = s.FullPath;
                        cmd.Parameters.Add("@Length", SqlDbType.VarChar, 50).Value = s.Length;
                        cmd.Parameters.Add("@PlayCount", SqlDbType.Int).Value = s.PlayCount;
                        cmd.Parameters.Add("@SkipCount", SqlDbType.Int).Value = s.SkipCount;
                        cmd.Parameters.Add("@LastPlayed", SqlDbType.VarChar, 50).Value = s.LastPlayed;
                        int rows = cmd.ExecuteNonQuery();
                        sqlcon.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not insert. {0}", s.Name);
                    Console.WriteLine("Error Message {0}", ex.Message);
                }
            }
        }
