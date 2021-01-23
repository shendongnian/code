    public class EntityToViewModelProfile : Profile
    {
    	protected override void Configure()
    	{
    		//Create mappings for Person and Address
    		AutoMapper.Mapper.CreateMap<Person, AdminViewModel>();
    		AutoMapper.Mapper.CreateMap<Address, AdminViewModel>();
    		
    		
    		//Create a map to AdminViewModel for both Person and Address
    
    		Mapper.CreateMap<Models.Person, Models.AdminViewModel>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src));
            Mapper.CreateMap<Models.Address, Models.AdminViewModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src));
    	}
    }
