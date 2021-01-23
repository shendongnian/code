    public void Process(ITelemetry item)
    {
        RequestTelemetry requestTelemetry = item as RequestTelemetry;
        if (requestTelemetry != null && int.Parse(requestTelemetry.ResponseCode) == (int)HttpStatusCode.NotFound)
        {
            return;
        }
        this.Next.Process(item);
    }
