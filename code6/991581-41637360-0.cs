                List<string> availableFiles = new List<string>();
                string line = string.Empty;
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        line = streamReader.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            if (line[0] != 'd')
                            {
                                availableFiles.Add(line.Split(new char[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries)[8]);
                            }
                            line = streamReader.ReadLine();
                        }
                    }
                }
