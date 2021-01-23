    public sealed class Areas
    {
        public int idarea { get; set; }
        public string areaname { get; set; }
        public List<Positions> positions { get; set; }
        public class Areas()
        {
             positions = new List<Positions>();
        }
    }
