    static IServiceCollection UseQueue<T>(this IServiceCollection services, 
                                          RabbitMQOptions options) 
            where T : class, IEventHandler
        {
            if (services == null)
                throw new ArgumentNullException("services");
            if (options == null)
                throw new ArgumentNullException("options");
            services.AddTransient<T>();
            services.AddTransient<IQueueService, QueueServiceImpl>();
            services.AddSingleton<RabbitMQOptions>(sp => { return options; });
            var serviceProvider = services.BuildServiceProvider();
            var rabbitImpl = serviceProvider.GetService<T>();
            var queueService = serviceProvider.GetService<IQueueService>();
            
            queueService.ReceivedMessage += async (sender, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                await rabbitImpl.MessageHandler(message);
                queueService.Channel.BasicAck(ea.DeliveryTag, false);
            };
            queueService.Start();
            return services;
        }
