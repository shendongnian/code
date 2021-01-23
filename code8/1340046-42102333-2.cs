     public static string HostName
            {
                get
                {
                    return ConfigurationManager.AppSettings["RabbitMQHostName"] ?? "";
                }
            }
