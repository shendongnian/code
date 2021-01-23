        var hostAddress = new Uri("rabbitmq://localhost/");
        var username = "guest";
        var password = "guest";
        _busControl = MassTransit.Bus.Factory.CreateUsingRabbitMq(configurator =>
        {
          var host = configurator.Host(hostAddress, h =>
          {
            h.Username(username);
            h.Password(password);
          });
          configurator.ReceiveEndpoint(host, "error_listener",
          endpointConfigurator =>
          {
            endpointConfigurator.Handler<Fault<SomeMessage>>(context =>
            {
              return Console.Out.WriteLineAsync("Woop");
            });
          });
        });
