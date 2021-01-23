                using (var client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    var html = client.DownloadString(url);
                    //This constructor prepares a StreamWriter (UTF-8) to write to the specified file or will create it if it doesn't already exist
                    using (var stream = new StreamWriter(file, false, Encoding.UTF8))
                    {
                        stream.Write(html);
                        stream.Close();
                    }
                }
