    public class ProposalController : Controller
    {
        private readonly IProposalDataRepository repProposal;
        public ProposalController(IProposalDataRepository repository) {
            repProposal = repository;
        }
        [HttpGet]
        public IEnumerable<Proposal> GetAll()
        {
            return repProposal.SelectAll();
        }
