    var table = JArray.Parse(jsonString);
    var format = "yyyyMMddHHmmss";
    var culture = CultureInfo.InvariantCulture; // Change if necessary
    var style = DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal; // Change if necessary.
    foreach (var property in table.Descendants().OfType<JProperty>().Where(p => (p.Name.Contains("DATE") || p.Name.Contains("TIME")) && p.Value.Type == JTokenType.String))
    {
        var value = (string)property.Value;
        DateTime date;
        if (DateTime.TryParseExact(value, format, culture, style, out date))
            property.Value = date;
    }
