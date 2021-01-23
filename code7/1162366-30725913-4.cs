    public class TreatmentBusiness
    {
        private readonly TreatmentRepositoryFactory repositoryFactory;
    
        public TreatmentBusiness(TreatmentRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }
        ...
    }
