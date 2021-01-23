    public class TreatmentBusiness
    {
        private readonly ITreatmentRepository repository;
    
        public TreatmentBusiness(ITreatmentRepository repository)
        {
            this.repository = repository;
        }
        ...
    }
