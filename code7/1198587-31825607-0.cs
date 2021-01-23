    public class DtoToEntityConverter : ITypeConverter<Dto, Entity>
    {
        private readonly IEntityRepository _entityRepository;
    
        public DtoToEntityConverter (IEntityRepository entityRepository )
        {
            _entityRepository = entityRepository ;
        }
    
        public Entity Convert(ResolutionContext context)
        {
    
        }     
    }
