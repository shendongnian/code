    public override void Validate(JToken value, JsonValidatorContext context)
    {
        var prop1 = value.SelectToken("..Prop1")?.Value<string>();
        var prop2 = value.SelectToken("..Prop2")?.Value<string>();
        // Rest of your logic...
    }
