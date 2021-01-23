    var errorId = GenerateErrorId();
    var trackProperties = new Dictionary<string, string>();
    trackProperties.Add("ErrorId", errorId);
    var ai = new TelemetryClient();
    ai.TrackException(exception, trackProperties);
    JObject resp = new JObject();
    resp["message"] = exception.Message + " - " + errorId;
    await context.Response.WriteAsync(resp.ToString());
