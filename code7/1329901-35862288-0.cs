    public class EFWalletRepository : IWalletRepository<EFWallet>
    {
        public void Create(EFWallet wallet)
        {
            _dataContext.Add(wallet);
        }
    }
