    foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
    {
        if (property.Key == ".issued")
        {
            context.AdditionalResponseParameters.Add(property.Key, context.Properties.IssuedUtc.Value.ToString("o", (IFormatProvider) CultureInfo.InvariantCulture));
        }
        else if (property.Key == ".expires")
        {
            context.AdditionalResponseParameters.Add(property.Key, context.Properties.ExpiresUtc.Value.ToString("o", (IFormatProvider) CultureInfo.InvariantCulture));
        }
        else
        {
            context.AdditionalResponseParameters.Add(property.Key, property.Value);
        }
    }
