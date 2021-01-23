    public class A
    {
        private static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<A, A>().ForMember(dest => dest.IsExpanded, opts => opts.Ignore())
                                 .ForMember(dest => dest.Children, 
                                            opt => opt.MapFrom(src => src.Children.Select(Mapper.Map<A, A>).ToList()));
        });
        private static IMapper mapper = config.CreateMapper();
        public string Name{get; set;}
        public bool IsExpanded{get; set;}
        public ObservableCollection<A> Children {get; set;}
        public void UpdateCurrenNode(A obj)
        {
           mapper.Map(obj, this);
        }
    }
