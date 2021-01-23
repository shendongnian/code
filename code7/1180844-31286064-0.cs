                List<String> newLine = new List<String>();
                while( ! content.EndOfStream)
                {
                    String line = content.ReadLine();                
                    if (line.Contains("causes"))
                    {
                        //add line to List
                        newLine.Add(line);
                    }
                }
            }
