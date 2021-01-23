    public class CurrencyRatesJob
        {
            private readonly ILogger _logger;
            private readonly Func<IBusinessTypeService> _businessTypeService;
    
            public CurrencyRatesJob(ILogger logger, Func<IBusinessTypeService> businessTypeService)
            {
                _logger = logger;
                _businessTypeService = businessTypeService;
            }
    
            public void Execute()
            {
                var types = _businessTypeService().GetBusinessTypes();
                _logger.Log("waqar");
    
            }
        }
