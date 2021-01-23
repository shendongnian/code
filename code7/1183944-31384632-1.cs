    public class Spatial_Element
    {
        [XmlElement("Spelement_Unit")]
        public List<Spelement_Unit> units;
        public Spatial_Element()
        {
            units = new List<Spelement_Unit>();
        }
    }
    public class Spelement_Unit
    {
        [XmlAttribute("Type_Unit")]
        public string type_unit;
        [XmlElement("NewOrdinate")]
        public NewOrdinate newOrdinate;
    }
    public class NewOrdinate
    {
        [XmlAttribute("X")]
        public string X;
        [XmlAttribute("Y")]
        public string Y;
        [XmlAttribute("Num_Geopoint")]
        public string Num_Geopoint;
    }
    public class Entity_Spatial
    {
        [XmlAttribute("Ent_Sys")]
        public string Ent_Sys;
        [XmlElement("Spatial_Element")]
        public List<Spatial_Element> Items;
        public Entity_Spatial()
        {
            Items = new List<Spatial_Element>();
        }
    }
