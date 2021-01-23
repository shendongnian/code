    public void ConfigureServices(IServiceCollection services)
    {
      //设置接收文件长度的最大值。
      services.Configure<FormOptions>(x =>
      {
          x.ValueLengthLimit = int.MaxValue;
          x.MultipartBodyLengthLimit = int.MaxValue;
          x.MultipartHeadersLengthLimit = int.MaxValue;
      });
      services.AddMvc();
    }
