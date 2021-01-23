    public class AzureBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var busControl = Bus.Factory.CreateUsingAzureServiceBus(sbc =>
                {
                    var host = sbc.Host(new Uri("sb://" + ConfigurationManager.AppSettings["AzureEndPoint"]), h =>
                    {
                        h.OperationTimeout = TimeSpan.FromSeconds(5);
                        h.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                            ConfigurationManager.AppSettings["AzureKeyName"],
                            ConfigurationManager.AppSettings["AzureKeyValue"]);
                    });
                    sbc.UseSerilog();
                    sbc.UseJsonSerializer();
                    //sbc.UseRetry(Retry.Exponential(10.Seconds(), 3.Minutes(), 10.Seconds()));
                    sbc.ReceiveEndpoint(host, ConfigurationManager.AppSettings["QueueName"], ep =>
                    {
                        ep.LoadFrom(context);
                    });
                });
                Log.Information("Finished Configuring MassTransit using Azure");
                return busControl;
            })
            .SingleInstance()
            .As<IBusControl>()
            .As<IBus>();
        }
    }
