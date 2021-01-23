     string directory = System.AppDomain.CurrentDomain.BaseDirectory;
                        DirectoryInfo dinfo = new DirectoryInfo(directory);
                        FileInfo[] Files = dinfo.GetFiles("*.txt");
        
                        List<string> lstData = new List<string>();
        
                        foreach (var file in Files)
                        {
                            using (StreamReader sr = File.OpenText(file.FullName))
                            {
                                string s = String.Empty;
                                while ((s = sr.ReadLine()) != null)
                                {
                                    if (!lstData.Contains(s))
                                    {
                                        lstData.Add(s);
                                    }
                                }
                            }
                        }
