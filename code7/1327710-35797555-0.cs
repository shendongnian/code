    public partial class ApplicationMappingsProfile
    {
        private void RegisterMappings()
        {
            CreateMap<Application, AppDto>()
                .ConvertUsing<ApplicationTypeConverter>();
        }
    }
    private class ApplicationTypeConverter : ITypeConverter<App, AppDto>
    {
        public AppDto Convert(ResolutionContext context)
        {
            var src = context.SourceValue as App;
            if (src == null)
            {
                return null;
            }
    
            var dto = Mapper.Map<App, AppDto>(src);
            dto.property = context.Engine.Mapper.Map.Map<Property>(src.SomeProperty);
    
            return result;
        }
    }
