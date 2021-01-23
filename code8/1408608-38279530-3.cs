    public class ConsumerWithInjection
    {
        private IDataService _service;
        public ConsumerWithInjection(IDataService service)
        {
            _service = service;
        }
    }
