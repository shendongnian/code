    public static void ReceiveMessage(string queuName)
        {
            var assembly = Assembly.GetCallingAssembly();
            string configPath = new Uri(assembly.CodeBase).LocalPath;
            var configManager = ConfigurationManager.OpenExeConfiguration(configPath);
            var connectionString = configManager.ConnectionStrings.CurrentConfiguration.AppSettings.Settings["Microsoft.ServiceBus.ConnectionString"];
            QueueClient Client = QueueClient.CreateFromConnectionString(connectionString, "Empresa");
            // Configure the callback options
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);
            // Callback to handle received messages
            Client.OnMessage((message) =>
            {
                try
                {
                    Empresa empresa = GetBody(message);
                    // Process message from queue
                    //Console.WriteLine("Body: " + );
                    Console.WriteLine("MessageID: " + message.MessageId);
                    // Remove message from queue
                    message.Complete();
                }
                catch (Exception ex)
                {
                    // Indicates a problem, unlock message in queue
                    message.Abandon();
                }
            }, options);
        }
