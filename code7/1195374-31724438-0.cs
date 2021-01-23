    public async void LoadFile(string file)
        {          
            using (var reader = new StreamReader(file))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }  
        }
