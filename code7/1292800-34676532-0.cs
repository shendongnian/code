     foreach(string file in Directory.EnumerateFiles(@"path comes here","*.csv"))
                {
                    Encoding ansi;
                    using (var reader = new System.IO.StreamReader(file, true))
                    {
                        ansi = reader.CurrentEncoding; // please tell what you have here ! :)
                    }
                    string text = File.ReadAllText(file, ansi);
                    text = text.Replace(@"++49", "'0");
                    text = text.Replace(@"+49", "'0");
                    text = text.Replace(@"""", "");
                    File.WriteAllText(file, text, ansi);
                }
