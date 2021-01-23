    enter code here
                 using (var client = new WebClient())
                 {
                string xmlData = new System.Net.WebClient().DownloadString("http://timesofindia.indiatimes.com/rssfeedstopstories.cms");
                  XmlDocument xml = new XmlDocument();
                     xml.LoadXml(xmlData);
                 
                XmlNodeList nodeList = xml.SelectNodes("/rss/channel/item");
                
                foreach (XmlNode node in nodeList)
                {
                    var title = node["title"].InnerText;
                    var description = node["description"].InnerText;
                    var link = node["link"].InnerText;
                    var guid = node["guid"].InnerText;
                    var pubdate = node["pubDate"].InnerText;
                    SqlConnection cnn = new SqlConnection(@"Data Source=vishal-pc\mssqlserver2012;Initial Catalog=aditya;User ID=sa;password=1234");
                    SqlCommand cmd = new SqlCommand("insert into XMLdata (title,description,link,guid,pubdate) VALUES (@xmlData,@xmlData1,@xmlData2,@xmlData3,@xmlData4)", cnn);
                
                    
                    //string sqlForInsert = "INSERT INTO XMLdata (title,description,link,guid,pubdate) VALUES (@xmlData,@xmlData1,@xmlData2,@xmlData3,@xmlData4);";
                    int rowsAffected = 0;
                    //try
                    //{
                    //    using (SqlConnection con = new SqlConnection(@"Data Source=vishal-pc\mssqlserver2012;Initial Catalog=aditya;User ID=sa;password=1234"))
                    //    using (SqlCommand cmd = new SqlCommand(sqlForInsert, con))
                        {
                            cmd.Parameters.Add(new SqlParameter("@xmlData", title));
                            cmd.Parameters.Add(new SqlParameter("@xmlData1", description));
                            cmd.Parameters.Add(new SqlParameter("@xmlData2", link));
                            cmd.Parameters.Add(new SqlParameter("@xmlData3", guid));
                            cmd.Parameters.Add(new SqlParameter("@xmlData4", pubdate));
                                cnn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            cnn.Close();
                        }
