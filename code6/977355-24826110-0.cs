    Class CultureEventViewModel
    private WebClient webclient
    public CultureEventViewModel()
    {
        CultureEvents = new List<CultureEvent>();
        WebClient webClient = new WebClient();
