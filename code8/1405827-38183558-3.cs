    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }
    
        public DomainToViewModelMappingProfile()
        {
            ConfigureMappings();
        }
    
    
        /// <summary>
        /// Creates a mapping between source (Domain) and destination (ViewModel)
        /// </summary>
        private void ConfigureMappings()
        {
            CreateMap<ProductDefinition, ProductDefinitionViewModel>().ReverseMap();
            CreateMap<CatalogueDefinitionFile, CatalogueDefinitionFileViewModel>().ReverseMap();
        }
    }
