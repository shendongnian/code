    public static string HostName { get; set; }
    public SomeConstructor()
            {
                HostName = ConfigurationManager.AppSettings["RabbitMQHostName"] ?? "";... }
 
