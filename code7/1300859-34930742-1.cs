    public static class DtoExtensions
    {
        public static CollectionMapper<TEntityDto> Map(this ICollection<TEntityDto> dtos)
            where TEntityDto : IEntityDto
        {
            return new CollectionMapper<TEntityDto>(dtos);
        }
    }
    public class CollectionMapper<TEntityDto> where TEntityDto : IEntityDto
    {
        private readonly ICollection<TEntityDto> dtos;
        public CollectionMapper(ICollection<TEntityDto> dtos)
        {
            this.dtos = dtos;
        }
        public ICollection<TEntity> To<TEntity>()
        {
            // Business rules...
            return AutoMapper.Mapper.Map<ICollection<TEntity>>(dtos);
        }
    }
