    public abstract class TransitReportBase : ITrnsitReport
    {
        private readonly IValidateInput _inputValidation;
        private readonly ITransitRepository _transitRepo;
        protected TransitReportBase(IValidateInput inputValidation,
                                ITransitRepository transitRepo)
        {
            _inputValidation = inputValidation;
            _transitRepo = transitRepo;
        }
        public List<UserDefinedType> GetTransitReportData(string input1, string input2)
        {
            List<UserDefinedType> ppdcReportList = null;
            bool isValid = _inputValidation.IsInputValid(input1, input2);
            if (isValid)
            {
                ppdcReportList = _transitRepo.GetTransitData(input1, input2);
                // do something with data
            }
            return ppdcReportList;
        }
    }
    
    public class PAITransitReport : TransitReportBase
    {
        public PAITransitReport([Dependency("PAI")] IValidateInput inputValidation,
                                [Dependency("PAI")] ITransitRepository transitRepo) : base(inputValidation, transitRepo)
        {
        }
    }
    public class PPDCTransitReport : TransitReportBase
    {
        public PPDCTransitReport([Dependency("PPDC")] IValidateInput inputValidation,
                                [Dependency("PPDC")] ITransitRepository transitRepo) : base(inputValidation, transitRepo)
        {
        }
    }
