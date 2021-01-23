    public class POI
    {
        Dictionary<string, List<string>> poi = new Dictionary<string, List<string>>();
        public bool ContainsKey(string key) { return this.poi.ContainsKey(key); }
        public List<string> GetValue(string key) { return this.poi[key]; }
        public void POIList()
        {
            foreach (string line in File.ReadLines("POIList.txt"))
            {
                string[] parts = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                
                if (parts.Length == 0)
                {
                    // Empty line or similar.
                    continue;
                }
                string cityName = parts[0];
                poi.Add(cityName, new List<string>());
                // Add the points of interest to local.
                var points = new List<string>(parts.Skip(1));
                poi[cityName] = points;
                var startPath = Application.StartupPath;
                string folderName = Path.Combine(startPath, "FinalJson");
                string cityDirectoryPath = Path.Combine(folderName, cityName);
                Directory.CreateDirectory(cityDirectoryPath);
            
                   }
        }
    }
