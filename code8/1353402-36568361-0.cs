    public interface IHandler // I usually split the generic and non-generic methods
    {
        Task AddAsync(IEnumerable<IDictionary<string, object>> toAdd, int dataFileId);
        Task AddAuditAsync(IEnumerable<IDictionary<string, object>> toAdd, int dataFileId);
    }
    public interface IHandler<TService, TServiceAudit> : IHandler
    {
        Task<IEnumerable<TService>> GetAsync();
        Task<IEnumerable<TServiceAudit>> GetAuditAsync();
    }
