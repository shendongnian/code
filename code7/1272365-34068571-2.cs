    var root = (JObject) JsonConvert.DeserializeObject(json);
    var dictionary = root
      .AsJEnumerable()
      .Cast<JProperty>()
      .ToDictionary(
        j => j.Name,
        j => j
          .Value
          .AsJEnumerable()
          .First()
          .AsJEnumerable()
          .Cast<JProperty>()
          .ToDictionary(k => k.Name, k => k.Value)
      );
