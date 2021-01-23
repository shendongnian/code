    public class FishContainer
    {
        [XmlArray("Fishies"), XmlArrayItem("Fish")]
        public List<FishData> Fishes { get; set; }
    
        public static FishContainer Load(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FishContainer), new XmlRootAttribute("FishContainer"));
            using (StringReader reader = new StringReader(xml))
                return (FishContainer)serializer.Deserialize(reader);
        }
    
        public FishData GetFishAttributeByName(string name)
        {
            return Fishes
                    .SingleOrDefault(fish => fish.Name.Equals(name));
        }
    }
