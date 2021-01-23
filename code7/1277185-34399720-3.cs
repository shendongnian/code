    [Atlas.Xml.XmlSerializationType(ChildElementName = "PorudzbenicaStavka")]
    public class Porudzbina : List<PorudzbenicaStavka>, IEnumerable<SqlDataRecord>
    {
        public long KomSifra { get; set; }
        public Guid KomId { get; set; }
        // ...
    }
    public class PorudzbenicaStavka
    {
        public int rb { get; set; }
        public string RobaSifra { get; set; }
        [XmlText]
        public string RobaNaziv { get; set;  }
    }
