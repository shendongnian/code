    namespace CoreAuroraService.Services
    {
        [DataContract]
        public class Patient 
        {
            [DataMember]
            public String LastName{get;set;}
        
            [DataMember]
            public string FirstName{get;set;}
        }
        
        [ServiceContract]
        public interface IPatientService
        {
            [OperationContract]
            [WebGet(UriTemplate = "/GetAllPatients", ResponseFormat = WebMessageFormat.Json)]
            List<Patient> GetAllPatients();
        
            [OperationContract]
            [WebInvoke(UriTemplate = "/Create", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
            bool CreatePatient();
        
        
            [OperationContract]
            [WebInvoke(UriTemplate = "/Update", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
            bool UpdatePatient(Guid patientGuid);
        
        
            [OperationContract]
            [WebInvoke(UriTemplate = "/Delete", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
            bool DeletePatient(Guid patientGuid);
        }
        
        public class PatientService : IPatientService
        {
            public List<Patient> GetAllPatients()
            {
                var patient = new Patient() { FirstName = "Jeem", LastName = "Street" };
                var patients = new List<Patient> { patient };
                return patients;
            }
        
            public bool CreatePatient()
            {
                // TODO: Implement the logic of the method here
                return true;
            }
        
            public bool UpdatePatient(Guid patientGuid)
            {
                // TODO: Implement the logic of the method here
                return true;
            }
        
            public bool DeletePatient(Guid patientGuid)
            {
                // TODO: Implement the logic of the method here
                return true;
            }
        }
    }
