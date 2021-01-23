    private void UnhandledError(object sender, UnhandledErrorDetectedEventArgs eventArgs)
    {
        try
        {
            eventArgs.UnhandledError.Propagate();
        }
        catch (Exception e)
        {
            var properties = new Dictionary<string, string>()
                {
                    { "trace", e.StackTrace },
                    { "mesage", e.Message },
                };
            telemetryClient.TrackCrash(e, properties);
        }
    }
