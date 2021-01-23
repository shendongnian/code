        public void UpdateInFile(string modified,int id)
        {
           string[] lines = File.ReadAllLines("items.txt");
           for (int i = 0; i < lines.Length; i++)
           {
              string[] parts = lines[i].Split(',');
              if (Convert.ToInt32(parts[0]) == id)
              {
                 lines[i] = modified;
              }
           }
           File.WriteAllLines("items.txt", lines);
       }
