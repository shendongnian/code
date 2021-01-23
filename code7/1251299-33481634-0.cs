     var tc = new TelemetryClient(); // Call once per thread
    
     // Send a user action or goal:
     tc.TrackEvent("Win Game");
    
     // Send a metric:
     tc.TrackMetric("Queue Length", q.Length);
    
     // Provide properties by which you can filter events:
     var properties = new Dictionary{"game", game.Name};
    
     // Provide metrics associated with an event:
     var measurements = new Dictionary{"score", game.score};
    
     tc.TrackEvent("Win Game", properties, measurements);
