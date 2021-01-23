    // Get the message
    BrokeredMessage message = ...
    try
    {
        // Process you message
        ...
        // Delete the message from the queue when it is ok.
        message.Complete();
        // Create and send an event to app insights
        var eventTelemetry = new EventTelemetry { Name = "MyQueueName" };
        eventTelemetry.Metrics["MessageCount"] = 1;
        telemetryClient.TrackEvent(eventTelemetry);
    }
    catch (Exception ex)
    {
        // Send back the message to the queue ??? depends if you'd like to re-process it
        message.Abandon();
 
        // Send the exception to app insights
        telemetryClient.TrackException(ex);
    }
