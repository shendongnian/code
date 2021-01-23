    public class SmallBizRepository : BaseQueryHelper, ISmallBizRepository
    {
        private SmallBizDbContext _ctx;
        public SmallBizRepository(SmallBizDbContext ctx, IQueryHelperRepository repo)
             : base(repo)
        {
            _ctx = ctx;
        }
        #region Clients
        public IQueryable GetClients(Guid firmid)
        {
            return TheRepository.GetClient(firmid);
        }
        #endregion
    }
