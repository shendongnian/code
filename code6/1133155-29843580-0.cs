    public class MainViewModel
    {
        private readonly ISampleService _sampleService;
        public MainViewModel(ISampleService sampleService)
        {
            _sampleService = sampleService   
        }
    }
