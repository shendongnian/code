    public override Task ApplyTokenResponse(ApplyTokenResponseContext context)
    {
        // Only add the custom parameters if the response is not a token error response.
        if (string.IsNullOrEmpty(context.Error))
        {
            context.Response["custom-property-1"] = "custom-value";
            context.Response["custom-property-2"] = JArray.FromObject(new[]
            {
                "custom-value-1",
                "custom-value-2"
            });
        }
        return Task.FromResult(0);
    }
