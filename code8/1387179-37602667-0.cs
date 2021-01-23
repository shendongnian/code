    public TDest ReadService<TSrc, TDest>(Func<IWebApiServiceResponse<TSrc>> func)
    {
        var type = typeof(TDest); //If you need the System.Type of TDest
        ...
        return Mapper.Map<TDest>(func());
    }
    var data = ReadService</*source type*/, CustomViewModel>(() => Services.CServices.CUsers());
