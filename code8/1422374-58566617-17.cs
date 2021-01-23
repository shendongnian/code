     public void ConfigureServices(IServiceCollection services)
            {
                services.Configure<FormOptions>(o =>  // currently all set to max, configure it to your needs!
                {
                    o.ValueLengthLimit = int.MaxValue;
                    o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
                    o.MultipartBoundaryLengthLimit = int.MaxValue;
                    o.MultipartHeadersCountLimit = int.MaxValue;
                    o.MultipartHeadersLengthLimit = int.MaxValue;
                });
