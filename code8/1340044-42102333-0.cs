    public static string HostName { get; set; }
    public SomeConstructor()
            {
                Host = ConfigurationManager.AppSettings["RabbitMQHostName"] ?? "";... }
 
