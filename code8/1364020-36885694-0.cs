    dynamic parsedJson = JsonConvert.DeserializeObject<dynamic>(str);
    Dynamic newStr = new ExpandoObject();
    newStr.Id = parsedJson.Id.ToString();
    newStr.Type = parsedJson.Type;
    ...
