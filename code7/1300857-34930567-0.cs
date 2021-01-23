    public static class ExtensionMethods
    {
        public static ICollection<TEntity> MapToCollection<TEntity, TEntityDto>(
            this ICollection<TEntityDto> dtos) where TEntityDto : IEntityDto
        {
            return AutoMapper.Mapper.Map<ICollection<TEntity>>(dtos);
        }        
    }
