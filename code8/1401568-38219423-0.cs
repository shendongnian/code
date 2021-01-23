    public static async Task<string> SendEvents(List<object> messages)
    {
        string eventHubName = "rcmds";
        var connectionString = GetServiceBusConnectionString();
        CreateEventHub(eventHubName, connectionString);
        var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
        try
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < messages.Count; i++)
            {
                var serializedMessage = JsonConvert.SerializeObject(messages[i]);
                EventData data = new EventData(Encoding.UTF8.GetBytes(serializedMessage));
                // Mesajları Event Hub a yolla
                tasks.Add(eventHubClient.SendAsync(data));
            }
            await Task.WhenAll(tasks.ToArray());
            System.Threading.Thread.Sleep(7000);
        }
        catch (Exception ex)
        {
            new ExceptionHandler(ex, "Event Hub Library Sender - SendEvents");
        }
        finally
        {
            await eventHubClient.CloseAsync();
        }
    
        return "";
    }
