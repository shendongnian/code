        static string[] SearchFiles(string[] filesSrc, string searchTerm)
        {
            List<string> result = new List<string>();
            string line = "";
            StreamReader reader = null;
                for (int i = 0; i < filesSrc.Length; i++)
                {
                    reader = new StreamReader(filesSrc[i]);
                    while ((line = reader.ReadLine()) != null)
                        if (line.Contains(searchTerm)) { result.Add(filesSrc[i]); break; }
                }
           
            reader.Dispose();
            return result.ToArray();
        }
