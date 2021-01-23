    public class DomainToViewModelMappingProfile : Profile
    {
    // etc ...
        private void ConfigureMappings()
        {
            // You are just creating a local mapper config/instance here and then discarding it when it goes out of scope...
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDefinition, ProductDefinitionViewModel>().ReverseMap();
                cfg.CreateMap<CatalogueDefinitionFile, CatalogueDefinitionFileViewModel>().ReverseMap();
    
            });
    
            IMapper mapper = config.CreateMapper();
    
            mapper.Map<ProductDefinition, ProductDefinitionViewModel>(new ProductDefinition());
            mapper.Map<CatalogueDefinitionFile, CatalogueDefinitionFileViewModel>(new CatalogueDefinitionFile());
    
    
        }
    }
