    using (var streamReader = new StreamReader("FilePath"))
            {
                if (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        string[] splitValues = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        if (splitValues[1] == txt_uname.Text)
                        {
                            // Stuff
                        }
                    }
                }
            }
