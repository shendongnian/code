    [XmlRoot(ElementName = "Sekretessmarkering")]
    public class Sekretessmarkering
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }
    [XmlRoot(ElementName = "PersonId")]
    public class PersonId
    {
        [XmlElement(ElementName = "PersonNr")]
        public string PersonNr { get; set; }
    }
    [XmlRoot(ElementName = "HanvisningsPersonNr")]
    public class HanvisningsPersonNr
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }
    [XmlRoot(ElementName = "Mellannamn")]
    public class Mellannamn
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }
    [XmlRoot(ElementName = "Aviseringsnamn")]
    public class Aviseringsnamn
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }
    [XmlRoot(ElementName = "Namn")]
    public class Namn
    {
        [XmlElement(ElementName = "Tilltalsnamnsmarkering")]
        public string Tilltalsnamnsmarkering { get; set; }
        [XmlElement(ElementName = "Fornamn")]
        public string Fornamn { get; set; }
        [XmlElement(ElementName = "Mellannamn")]
        public Mellannamn Mellannamn { get; set; }
        [XmlElement(ElementName = "Efternamn")]
        public string Efternamn { get; set; }
        [XmlElement(ElementName = "Aviseringsnamn")]
        public Aviseringsnamn Aviseringsnamn { get; set; }
    }
    [XmlRoot(ElementName = "ForsamlingKod")]
    public class ForsamlingKod
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }
    [XmlRoot(ElementName = "Folkbokforing")]
    public class Folkbokforing
    {
        [XmlElement(ElementName = "Folkbokforingsdatum")]
        public string Folkbokforingsdatum { get; set; }
        [XmlElement(ElementName = "LanKod")]
        public string LanKod { get; set; }
        [XmlElement(ElementName = "KommunKod")]
        public string KommunKod { get; set; }
        [XmlElement(ElementName = "ForsamlingKod")]
        public ForsamlingKod ForsamlingKod { get; set; }
        [XmlElement(ElementName = "Fastighetsbeteckning")]
        public string Fastighetsbeteckning { get; set; }
        [XmlElement(ElementName = "FiktivtNr")]
        public string FiktivtNr { get; set; }
    }
    [XmlRoot(ElementName = "CareOf")]
    public class CareOf
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }
    [XmlRoot(ElementName = "Utdelningsadress1")]
    public class Utdelningsadress1
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }
    [XmlRoot(ElementName = "Folkbokforingsadress")]
    public class Folkbokforingsadress
    {
        [XmlElement(ElementName = "CareOf")]
        public CareOf CareOf { get; set; }
        [XmlElement(ElementName = "Utdelningsadress1")]
        public Utdelningsadress1 Utdelningsadress1 { get; set; }
        [XmlElement(ElementName = "Utdelningsadress2")]
        public string Utdelningsadress2 { get; set; }
        [XmlElement(ElementName = "PostNr")]
        public string PostNr { get; set; }
        [XmlElement(ElementName = "Postort")]
        public string Postort { get; set; }
    }
    [XmlRoot(ElementName = "Riksnycklar")]
    public class Riksnycklar
    {
        [XmlElement(ElementName = "FastighetsId")]
        public string FastighetsId { get; set; }
        [XmlElement(ElementName = "AdressplatsId")]
        public string AdressplatsId { get; set; }
        [XmlElement(ElementName = "LagenhetsId")]
        public string LagenhetsId { get; set; }
    }
    [XmlRoot(ElementName = "Adresser")]
    public class Adresser
    {
        [XmlElement(ElementName = "Folkbokforingsadress")]
        public Folkbokforingsadress Folkbokforingsadress { get; set; }
        [XmlElement(ElementName = "Riksnycklar")]
        public Riksnycklar Riksnycklar { get; set; }
    }
    [XmlRoot(ElementName = "HemortSverige")]
    public class HemortSverige
    {
        [XmlElement(ElementName = "FodelselanKod")]
        public string FodelselanKod { get; set; }
        [XmlElement(ElementName = "Fodelseforsamling")]
        public string Fodelseforsamling { get; set; }
    }
    [XmlRoot(ElementName = "Fodelse")]
    public class Fodelse
    {
        [XmlElement(ElementName = "HemortSverige")]
        public HemortSverige HemortSverige { get; set; }
    }
    [XmlRoot(ElementName = "Medborgarskap")]
    public class Medborgarskap
    {
        [XmlElement(ElementName = "MedborgarskapslandKod")]
        public string MedborgarskapslandKod { get; set; }
        [XmlElement(ElementName = "Medborgarskapsdatum")]
        public string Medborgarskapsdatum { get; set; }
    }
    [XmlRoot(ElementName = "Personpost")]
    public class Personpost
    {
        [XmlElement(ElementName = "PersonId")]
        public PersonId PersonId { get; set; }
        [XmlElement(ElementName = "HanvisningsPersonNr")]
        public HanvisningsPersonNr HanvisningsPersonNr { get; set; }
        [XmlElement(ElementName = "Namn")]
        public Namn Namn { get; set; }
        [XmlElement(ElementName = "Folkbokforing")]
        public Folkbokforing Folkbokforing { get; set; }
        [XmlElement(ElementName = "Adresser")]
        public Adresser Adresser { get; set; }
        [XmlElement(ElementName = "Fodelse")]
        public Fodelse Fodelse { get; set; }
        [XmlElement(ElementName = "Medborgarskap")]
        public Medborgarskap Medborgarskap { get; set; }
    }
    [XmlRoot(ElementName = "FolkbokforingspostTYPE")]
    public class FolkbokforingspostTYPE
    {
        [XmlElement(ElementName = "Sekretessmarkering")]
        public Sekretessmarkering Sekretessmarkering { get; set; }
        [XmlElement(ElementName = "Personpost")]
        public Personpost Personpost { get; set; }
    }
