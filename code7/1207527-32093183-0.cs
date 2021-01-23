    [XmlRoot(ElementName = "PatientDS")]
    public class PatientDS
    {
       public Patient Patient { get; set; }
    }
    [XmlRoot(ElementName = "Patient")]
    public class Patient
    {
       //stuff
    }
