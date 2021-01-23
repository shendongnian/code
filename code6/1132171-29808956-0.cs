            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(@"C:\sample.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    //Add your conditional logic to add the line to an array
                    if (line.Contains(searchTerm)) {
                        lines.Add(line);
                    }
                }
            }
