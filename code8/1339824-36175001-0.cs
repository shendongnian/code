    private IDealsService DealsService {get; set;}
    private IDealsParser DealParser {get; set;}
    //etc...
    protected void Page_Init(object sender, EventArgs e, IDealsService dealsService, IDealsParser dealParser)
    {
        DealsService = dealsService;
        DealParser = dealParser;
        //etc...
    }
