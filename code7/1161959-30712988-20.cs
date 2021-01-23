    public class TheConsultationClass
    {
        public MyFactory Factory { get; set; }
        public TheConsultationClass(IFactory factory)
        {
            Factory = factory;
        }
        public void AddConsultation(ConsultationView cv, int patientid)
        {
            using (var deprepo = Factory.Create())
            {
                if (cv.ConsultId == 0)
                {
                    var curr = DateTime.Now;
                    string date = curr.ToString("d");
                    string time = curr.ToString("t");
                    var patient = da.Patients.ToList().Find(x => x.PatientId == patientid);
                    Consultation _consultation = new Consultation
                    {
                        ConsultId = cv.ConsultId,
                        ConsultDate = date,
                        ConsultTime = time,
                        illness = cv.illness,
                        PresribedMed = cv.PresribedMed,
                        Symptoms = cv.Symptoms,
                        U_Id = patient.PatientId,
                    };
                    deprepo.Insert(_consultation);
                }
            }
        }
    }
    
