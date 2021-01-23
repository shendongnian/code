     public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
            {
                log.WriteLine(message);
                string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
                Console.WriteLine("this is my webjob project console write " + connectionString);
            }
