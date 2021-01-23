    public interface ICommonService<TDto> where TDto : IDtoCommon
    {
        Task<string> UpdatePosition(TDto @object);
    }
    public class CommonService<TDto, TEntity> : ICommonService<TDto>
        where TDto : IDtoCommon
        where TEntity : IEntityCommon
    {
        private readonly IRepository<TEntity> m_Repository;
        public CommonService(IRepository<TEntity> repository)
        {
            m_Repository = repository;
        }
        public async Task<string> UpdatePosition(TDto @object)
        {
            var entity = await m_Repository.FindAsync(@object.Id);
            entity.PosLeft = @object.PosLeft;
            entity.PosTop = @object.PosTop;
            await m_Repository.Update(entity);
            return entity.Id.Value; 
        }
    }
