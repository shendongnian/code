    JobHostConfiguration config = new JobHostConfiguration();
    ServiceBusConfiguration sbConfig = new ServiceBusConfiguration();
    sbConfig.OnMessageOptions = new OnMessageOptions
    {
      MaxConcurrentCalls = 16,
      AutoRenewTimeout = TimeSpan.FromMinutes(10)
    };
    config.UseServiceBus(sbConfig);
