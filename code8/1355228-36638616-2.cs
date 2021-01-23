    public interface IService<TModel>
    {
        TModel Find(params object[] keyValues);
        Task<TModel> Insert(TModel model);
        IEnumerable<TModel> InsertRange(IEnumerable<TModel> models);
        Task<TModel> Update(TModel model);
        void Delete(object id);
        void Delete(TModel model);
        Task<TModel> FindAsync(params object[] keyValues);
        Task<TModel> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
    public abstract class Service<TModel, TEntity> : IService<TModel> where TEntity : class, IObjectState
    {
        #region Private Fields
        private readonly IRepositoryAsync<TEntity> _repository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMapper _mapper;
        #endregion Private Fields
        #region Constructor
        protected Service(IRepositoryAsync<TEntity> repository, IUnitOfWorkAsync unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion Constructor
        public void Delete(TModel model)
        {
            _unitOfWork.RepositoryAsync<TEntity>().Delete(_mapper.Map<TEntity>(model));
            _unitOfWork.SaveChanges();
        }
        public void Delete(object id)
        {
            _unitOfWork.RepositoryAsync<TEntity>().Delete(id);
            _unitOfWork.SaveChanges();
        }
        public async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await DeleteAsync(CancellationToken.None, keyValues);
        }
        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var result = await _unitOfWork.RepositoryAsync<TEntity>().DeleteAsync(cancellationToken, keyValues);
            _unitOfWork.SaveChanges();
            return result;
        }
        public TModel Find(params object[] keyValues)
        {
            return _mapper.Map<TModel>(_repository.Find(keyValues));
        }
        public async Task<TModel> FindAsync(params object[] keyValues)
        {
            var entity = await _repository.FindAsync(keyValues);
            return _mapper.Map<TModel>(entity);
        }
        public async Task<TModel> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entity = await _repository.FindAsync(cancellationToken, keyValues);
            return _mapper.Map<TModel>(entity);
        }
        public async Task<TModel> Insert(TModel model)
        {
            var entity = _unitOfWork.RepositoryAsync<TEntity>().Insert(_mapper.Map<TEntity>(model));
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TModel>(entity);
        }
        public IEnumerable<TModel> InsertRange(IEnumerable<TModel> models)
        {
            var entities = _unitOfWork.RepositoryAsync<TEntity>().InsertRange(_mapper.Map<IEnumerable<TEntity>>(models));
            _unitOfWork.SaveChanges();
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }
        public async Task<TModel> Update(TModel model)
        {
            var entity = _unitOfWork.RepositoryAsync<TEntity>().Update(_mapper.Map<TEntity>(model));
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TModel>(entity);
        }
        public async Task<TModel> UpdateFieldsOnly(TModel model, params string[] fields)
        {
            var entity = _unitOfWork.RepositoryAsync<TEntity>().UpdateFieldsOnly(_mapper.Map<TEntity>(model), fields);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TModel>(entity);
        }
    }
