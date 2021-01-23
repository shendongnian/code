    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            //Example here, creates "two way" for Overview & OverviewViewModel mapping
            Mapper.CreateMap<Overview, OverviewViewModel>(); //<source, destination>
            Mapper.CreateMap<OverviewViewModel, Overview>(); //<source, destination>
            //..more mapping for other Models and ViewModels.
        }
    }
