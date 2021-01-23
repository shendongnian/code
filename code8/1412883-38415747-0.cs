                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    cmd.Parameters.Add(new SqlParameter("Name", s.Name));
                    cmd.Parameters.Add(new SqlParameter("Id", s.Id));
                    cmd.Parameters.Add(new SqlParameter("Album", s.Album));
                    cmd.Parameters.Add(new SqlParameter("TrackNumber", s.TrackNumber));
                    cmd.Parameters.Add(new SqlParameter("TrackNumberCount", s.TrackNumberCount));
                    cmd.Parameters.Add(new SqlParameter("Genre", s.Genre));
                    cmd.Parameters.Add(new SqlParameter("Rating", s.Rating));
                    cmd.Parameters.Add(new SqlParameter("Tags", s.Tags));
                    cmd.Parameters.Add(new SqlParameter("Subject", s.Subject));
                    cmd.Parameters.Add(new SqlParameter("Categories", s.Categories));
                    cmd.Parameters.Add(new SqlParameter("Comments", s.Comments));
                    cmd.Parameters.Add(new SqlParameter("FileName", s.FileName));
                    cmd.Parameters.Add(new SqlParameter("FolderName", s.FolderName));
                    cmd.Parameters.Add(new SqlParameter("FolderPath", s.FolderPath));
                    cmd.Parameters.Add(new SqlParameter("FullPath", s.FullPath));
                    cmd.Parameters.Add(new SqlParameter("Length", s.Length));
                    cmd.Parameters.Add(new SqlParameter("PlayCount", s.PlayCount));
                    cmd.Parameters.Add(new SqlParameter("SkipCount", s.SkipCount));
                    cmd.Parameters.Add(new SqlParameter("LastPlayed", s.LastPlayed));
                    cmd.ExecuteNonQuery();
                    for (int i = 1; i <= 500; i++)
                    {
                        cmd.Parameters["Name"].Value = "My Song Name " + i.ToString("D3");
                        cmd.Parameters["Id"].Value = i.ToString();
                        ...All parameters...
                        cmd.ExecuteNonQuery();
                    }
                    sqlcon.Close();
