    public class TreatmentBusiness
    {
        private readonly Func<TreatmentRepository> getTreatmentRepository;
        public TreatmentBusiness(Func<TreatmentRepository> getTreatmentRepository)
        {
                this.getTreatmentRepository = getTreatmentRepository;
        }
        ....
    }
