    public class CSVShipRepository : IShipRepository
    {
        private readonly string filePath;
        public CSVShipRepository(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");
            this.filePath = filePath;
        }
        public List<Ship> GetShips()
        {
            var res = new List<Ship>();
            try
            {
                string fileData;
                using (var sr = new StreamReader(filePath))
                {
                    fileData = sr.ReadToEnd();
                }
                //class, attack, engine, shield
                string[] lines = fileData.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                bool first = true;
                foreach (var line in lines)
                {
                    if (first)
                    {//jump over the first line (the CSV header line)
                        first = false; continue;
                    }
                    string[] values = line.Split(new string[] { "," }, StringSplitOptions.None)
                        .Select(p=>p.Trim()).ToArray();
                    if (values.Length != 4) continue;
                    var ship = new Ship() { 
                        Class=values[0],
                        Attack=int.Parse(values[1]),
                        Engine = int.Parse(values[2]),
                        Shield = int.Parse(values[3]),
                    };
                    res.Add(ship);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error reading file: " + ex.Message);
            }
            
            return res;
        }
    }
