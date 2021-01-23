    public class Out: Profile
    {
       protected override void Configure()
        {
            CreateMap<Step1, PersonalDetails>();
            CreateMap<Step2, Phones>();
            CreateMap<Step3, ElectonicCommunication>();
    
            CreateMap<Params, Parameters>();
            CreateMap<Params, RequestContent>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RequestId))
                .ForAllMembers(opt => opt.Ignore());
            CreateMap<Steps, RequestContent>()
                .ForMember(dest => dest.PersonalDetails, opt => opt.MapFrom(src => src.Step1))
                .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Step2))
                .ForMember(dest => dest.ElectonicCommunication, opt => opt.MapFrom(src => src.Step3))
                .ForAllMembers(opt => opt.Ignore());
    
            CreateMap<MvcModel, Request>()
                .ForMember(dest => dest.Parameters, opt => opt.MapFrom(src => src.Params))
                .ForMember(dest => dest.RequestContent, opt => opt.MapFrom(src => src.Steps));
        }
    }
