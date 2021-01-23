    public static void Main()
    {
        dynamic arr = JArray.Parse(JSON); // response = json string above
        foreach (dynamic token in arr)
        {
            JToken value = ExtractValue(token);
            Console.WriteLine(value);
        }
    }
    private static JToken ExtractValue(dynamic token)
    {
        string tokenvalue = (string) token.value;
        JToken value = Regex.IsMatch(tokenvalue, "^\\{.*\\}$")
            ? JToken.Parse(tokenvalue)
            : token.value;
        switch (value.Type)
        {
            case JTokenType.String:
                return value;
            case JTokenType.Object:
                return ExtractValue(((dynamic) value).results.Last);
            default:
                throw new InvalidOperationException("Could not extract data, unknown json construct.");
        }
    }
