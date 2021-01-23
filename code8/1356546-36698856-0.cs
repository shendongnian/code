    using System;
    using Autofac;
    using Microsoft.ServiceFabric.Services.Remoting.Client;
    public class MyAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(component => ServiceProxy.Create<IMyService>(new Uri("fabric:/App/MyService"))).As<IMyService>();
            // Other services...
        }
    }
