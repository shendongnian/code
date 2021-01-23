    public class AddBaseProductCommandConverter : ITypeConverter<AddBaseProductService.AddBaseProduct, AddBaseProductCommand>
    {
        public AddBaseProductCommand Convert(ResolutionContext context)
        {
            if (context.SourceValue == null || !(context.SourceValue is AddBaseProductService.AddBaseProduct))
                throw new AutoMapperMappingException();
            var mapper = context.Engine.Mapper;
            ...
        }
    }
