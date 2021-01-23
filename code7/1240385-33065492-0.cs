    public interface IContractWindowViewModelFactory
    {
        ContractWindowViewModel CreateForNewContract();
        ContractWindowViewModel CreateForExistingContract(Contract existing_contract);
    }
    public class ContractWindowViewModelFactory : IContractWindowViewModelFactory
    {
        private readonly IRepository<Contract> m_Repository;
        public ContractWindowViewModelFactory(IRepository<Contract> repository)
        {
            m_Repository = repository;
        }
        public ContractWindowViewModel CreateForNewContract()
        {
            return new ContractWindowViewModel(m_Repository);
        }
        public ContractWindowViewModel CreateForExistingContract(Contract existing_contract)
        {
            return new ContractWindowViewModel(existing_contract, m_Repository);
        }
    }
