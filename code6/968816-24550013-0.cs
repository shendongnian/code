    public class Vehicule
    {
        public int Year { get; set; }
        public int CarCode { get; set; }
        public int BikeCode { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Year, CarCode, BikeCode);
        }
    }
    public class FileStorage
    {
        public List<Vehicule> GetVehicules(string filePath)
        {
            return File.ReadAllLines(filePath).Select(s => s.Split(',')).Select(split => new Vehicule
            {
                Year = int.Parse(split[0]),
                CarCode = int.Parse(split[1]),
                BikeCode = int.Parse(split[2])
            }).ToList();
        }
        public void WriteVehicules(string filePath, IEnumerable<Vehicule> vehicules)
        {
            File.WriteAllLines(filePath, vehicules.Select(s => s.ToString()));
        }
    }
