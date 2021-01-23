    string[] files;
                while (sending)
                {
                    files = Directory.GetFiles(Events_Directory, "*.xml");
                    foreach (string file in files)
                    {
                        StreamReader IN = new StreamReader(file);
                        string allText = IN.ReadToEnd();
                        IN.Close();
                        Message = System.Text.UTF8Encoding.ASCII.GetBytes(Regex.Replace(
                                            allText, @"[\r\n\t ]+", ""));
                        Sock.Send(Message);
                        File.Delete(file);
                    }
                }
