    string path=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"32901448","InputFle.txt");
                string[] lines = File.ReadAllLines(path);
                List<string> linesOut = new List<string>();
                foreach (string line in lines)
                {
                    if (line.ToUpper().Trim() == "BLUE")
                    {
                        linesOut.Add("YELLOW");    
                    }
                    linesOut.Add(line);
                }
    
                File.WriteAllLines(path, linesOut);
