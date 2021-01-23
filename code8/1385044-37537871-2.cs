    public void Process(ITelemetry item)
        {
            RequestTelemetry requestTelemetry = item as RequestTelemetry;
            if (requestTelemetry != null && int.Parse(requestTelemetry.ResponseCode) == (int)HttpStatusCode.BadRequest)
            {
                return;
            }
            this.Next.Process(item);
        }
