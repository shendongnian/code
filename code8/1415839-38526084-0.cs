            XElement rssFeeds = null;
            using (var client = new WebClient())
            {
                try
                {
                    string rssString = new System.Net.WebClient().DownloadString("http://timesofindia.indiatimes.com/rssfeedstopstories.cms");
                    rssFeeds = XElement.Parse(rssString);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            if (rssFeeds != null)
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=vishal-pc\mssqlserver2012;Initial Catalog=aditya;User ID=sa;password=1234"))
                {
                    con.Open();
                    var tran = con.BeginTransaction();
                    try
                    {
                        rssFeeds.Descendants("item").ToList().ForEach(e =>
                        {
                            string insertSql = @"insert into XMLdata (title,description,link,guid,pubdate) VALUES (@title,@description,@link,@guid,pubdate)";
                            SqlCommand cmd = new SqlCommand(insertSql, con, tran);
                            cmd.Parameters.Add(new SqlParameter("title", e.Element("title").Value));
                            cmd.Parameters.Add(new SqlParameter("description", e.Element("description").Value));
                            cmd.Parameters.Add(new SqlParameter("link", e.Element("link").Value));
                            cmd.Parameters.Add(new SqlParameter("guid", e.Element("guid").Value));
                            cmd.Parameters.Add(new SqlParameter("pubdate", e.Element("pubDate").Value));
                            cmd.ExecuteNonQuery();
                        });
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
