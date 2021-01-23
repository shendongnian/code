     public void ConfigureServices(IServiceCollection services)
            {
                services.Configure<FormOptions>(o =>
                {
                    o.ValueLengthLimit = int.MaxValue;
                    o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
                    o.MultipartBoundaryLengthLimit = int.MaxValue;
                    o.MultipartHeadersCountLimit = int.MaxValue;
                    o.MultipartHeadersLengthLimit = int.MaxValue;
                });
