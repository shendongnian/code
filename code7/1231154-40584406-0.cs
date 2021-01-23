                var endpointUri = ServiceBusEnvironment.CreateServiceUri("sb", eventHubNamespace, string.Empty);
                MessagingFactory factory = MessagingFactory.Create(endpointUri, new MessagingFactorySettings
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(sasToken),
                    TransportType = TransportType.Amqp
                });
                factory.RetryPolicy = new RetryExponential(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(30), 3);
                client = factory.CreateEventHubClient(eventHubName);
