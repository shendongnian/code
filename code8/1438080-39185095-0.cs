    public class PLATFORM
    {
        public string LINIE { get; set; }
        public string ECHTZEIT { get; set; }
        public string VERKEHRSMITTEL { get; set; }
        public string RBL_NUMMER { get; set; }
        public string BEREICH { get; set; }
        public string RICHTUNG { get; set; }
        public string REIHENFOLGE { get; set; }
        public string STEIG { get; set; }
        public string STEIG_WGS84_LAT { get; set; }
        public string STEIG_WGS84_LON { get; set; }
    }
    
    public class RootObject
    {
        public string HALTESTELLEN_ID { get; set; }
        public string TYP { get; set; }
        public string DIVA { get; set; }
        public string NAME { get; set; }
        public string GEMEINDE { get; set; }
        public string GEMEINDE_ID { get; set; }
        public string WGS84_LAT { get; set; }
        public string WGS84_LON { get; set; }
        public string STAND { get; set; }
        public List<PLATFORM> PLATFORMS { get; set; }
        public List<string> LINES { get; set; }
    }
