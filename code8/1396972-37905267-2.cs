    public class FishContainer
    {
        private static FishContainer _instance;
        
        [XmlArray("Fishies"), XmlArrayItem("Fish")]
        public List<FishData> Fishes { get; set; }
    
        public static void Load(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FishContainer), new XmlRootAttribute("FishContainer"));
            using (StringReader reader = new StringReader(xml))
                _instance = (FishContainer)serializer.Deserialize(reader);
        }
    
        public static FishData GetFishAttributeByName(string name)
        {
            if (_instance == null)
                throw new InvalidOperationException("FishContainer has not been loaded");
            return 
                _instance
                .Fishes
                .SingleOrDefault(fish => fish.Name.Equals(name));
        }
    }
