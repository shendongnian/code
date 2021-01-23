    public class ExampleClass 
    {
        private readonly IMapper _mapper;
        public ExampleClass(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void DoWork()
        {
            var model = new LatestUpdateModel();
            ...
            var update = mapper.Map<LatestUpdateModel, LatestUpdate>(model);
        }
    }
