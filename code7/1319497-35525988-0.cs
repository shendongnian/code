    public void InsertAllEpisodes(List<TVDBSharp.Models.Show> showList)
        {
            using (SQLiteConnection dbconnection = new SQLiteConnection(connectionString))
            {
                dbconnection.Open();
                string seasonNumber;
                string episodeNumber;
                string insertShowSQL = @"INSERT INTO AllEpisodes (Key, ShowName, ShowId, EpisodeName, SeasonEpisode) VALUES (@Key, @ShowName, @ShowId, @EpisodeName, @SeasonEpisode)";
                SQLiteCommand sqlComm;
                sqlComm = new SQLiteCommand("begin", dbconnection);
                sqlComm.ExecuteNonQuery();
                foreach (var show in showList)
                {
                    foreach (var episode in show.Episodes)
                    {
                        if (episode.SeasonNumber != 0)
                        {
                            string seasonEpisode = "default";
                            if ((episode.SeasonNumber != 0) && (episode.SeasonNumber.ToString().Length == 1)) { seasonNumber = "0" + episode.SeasonNumber.ToString(); }
                            else { seasonNumber = episode.SeasonNumber.ToString(); }
                            if (episode.EpisodeNumber.ToString().Length == 1) { episodeNumber = "0" + episode.EpisodeNumber.ToString(); }
                            else { episodeNumber = episode.EpisodeNumber.ToString(); }
                            seasonEpisode = seasonNumber + episodeNumber;
                            sqlComm = new SQLiteCommand(insertShowSQL, dbconnection);
                            sqlComm.Parameters.AddWithValue("Key", show.Id + seasonEpisode);
                            sqlComm.Parameters.AddWithValue("ShowName", show.Name);
                            sqlComm.Parameters.AddWithValue("ShowId", show.Id);
                            sqlComm.Parameters.AddWithValue("EpisodeName", episode.Title);
                            sqlComm.Parameters.AddWithValue("SeasonEpisode", seasonEpisode);
                            try
                            {
                                sqlComm.ExecuteScalar();
                            }
                            catch (SQLiteException ex)
                            {
                                if (ex.ResultCode != SQLiteErrorCode.Constraint)
                                {
                                    File.AppendAllText(programDataPath + "SQLErrors.txt", ex.Message + "\n");
                                }
                            }
                            
                        }
                    }
                    
                }
                sqlComm = new SQLiteCommand("end", dbconnection);
                sqlComm.ExecuteNonQuery();
                dbconnection.Close();
                
            }
        }
