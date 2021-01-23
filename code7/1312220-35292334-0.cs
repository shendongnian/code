    IWebAPIRepository WebAPI { get; set; }
    
    public WebAPIController([FromServices] IWebAPIRepository API)
    {
            WebAPI = API;
    }
