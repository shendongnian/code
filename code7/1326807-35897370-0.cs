    [ServiceContract]
    [XmlSerializerFormat]
    public interface IPatientInfoService
    {
        [OperationContract]
        public void ProcessPatientInfo(PatientInfo patient)
        {
            // Code not shown.
        }
    }
    [XmlRoot("PatientInfo")]
    public class PatientInfo
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("SSN")]
        public string SSN { get; set; }
        [XmlElement("Birthday")]
        public DateTime? Birthday { get; set; }
        [XmlElement("RequestedClientID")]
        public Guid RequestedClientID { get; set; }
        [XmlElement("patientId")]
        public Guid patientId { get; set; }
    }
