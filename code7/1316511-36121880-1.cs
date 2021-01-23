    async Task IEventProcessor.ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
    {
        foreach (EventData eventData in messages)
        {
            var jsonBody = Encoding.UTF8.GetString(eventData.GetBytes());
            //Get the event type
            var eventTypeName = (string)eventData.Properties["EventType"];
            var eventType = Type.GetType(eventTypeName);
            // Deserialize the object
            var myPoco = JsonConvert.DeserializeObject(jsonBody, eventType);
        }
    }
