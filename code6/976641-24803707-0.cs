    [XmlRoot("root")]
    public class Destinataires
    {
        [XmlArray("Destinataires")]
        [XmlArrayItem("Destinataire")]
        public ObservableCollection<XML_Arret> Collection { get; set; }
    }
