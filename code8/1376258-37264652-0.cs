    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            //Example here, creates "two way" mapping
            AutoMapper.Mapper.CreateMap<Overview, OverviewViewModel>(); //<source, destination>
            AutoMapper.Mapper.CreateMap<OverviewViewModel, Overview>(); //<source, destination>
            //..more mapping for other Models and ViewModels.
        }
    }
