    public class TreatmentBusiness
    {
        private readonly ITreatmentRepositoryFactory repositoryFactory;
    
        public TreatmentBusiness(ITreatmentRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }
        ...
    }
