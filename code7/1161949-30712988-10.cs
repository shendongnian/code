    public class ConsultationTestRpository : IConsultationRepository
    {
        //Your test repository. In this you skip the database.
        //This is just one simple example of doing it.
        Consultation _consultation;
        public Consultation GetById(int id)
        {
            return _consultation;
        }
        public void Insert(Consultation model)
        {
            _consultation = model;
        }
    }
    public class ConsultationRepository : IConsultationRepository
    {
        //Your repository
    }
