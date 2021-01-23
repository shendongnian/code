    public static void Configure(params Action<MapperConfigurationExpression>[] registerCallbacks)
    {
            MapperConfigurationExpression configuration = new MapperConfigurationExpression();
            foreach (Action<MapperConfigurationExpression> regCallBack in registerCallbacks)
            {
                regCallBack.Invoke(configuration);
            }
            AutoMapper.Mapper.Initialize(configuration);
    }
