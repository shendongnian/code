    async Task IEventProcessor.ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
    {
        foreach (EventData eventData in messages)
        {
            var jsonBody = Encoding.UTF8.GetString(eventData.GetBytes());
            // Deserialize the json as a JObject
            var myPoco = JObject.Parse(jsonBody);
            var a = myPoco["X"]["a"];
        }
    }
