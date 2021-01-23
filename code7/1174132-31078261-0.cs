            string[] lines;
            string somePath = @"C:\test\";
            foreach (string x in a)
            {
                string path = Path.Combine(somePath, x);
                lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length;i++)
                {
                    lines[i] = lines[i].Replace("AS", "");
                    string[] values = lines[i].Split(',');
                    if (values.Length >= 3)
                    {
                        string[] parts = values[2].Split('-');
                        if (parts.Length == 3)
                        {
                            values[2] = String.Format("{0}/{1}/{2}", parts[2], parts[1], parts[0]);
                            lines[i] = String.Join(",", values);
                        }
                    }
                }
                File.WriteAllLines(path, lines);
            }
