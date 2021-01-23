     [Serializable]
    public class Castle
    { 
        [XmlElement("Tower")]
        public Towers[] tower;
    }
    public class Towers
    { 
        [XmlElement("Roof")]
        public Roofs[] roof;
    }
    public class Roofs
    { 
        [XmlElement("Color")]
        public string color;
    }
