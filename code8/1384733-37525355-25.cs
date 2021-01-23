    public class MerchantService : IMerchantService
    {
        public Task<MerchantViewModel> Get(Expression<Func<IMerchantFilter, bool>> predicate)
        {
            ...
        }
        ...
    }
    public class MerchantRepository : ...
    {
        public async Task<IEnumerable<Merchant>> GetItemsAsync(
            Expression<Func<IMerchantFilter, bool>> predicate = null)
        {
            ...
        }
        ...
    }
