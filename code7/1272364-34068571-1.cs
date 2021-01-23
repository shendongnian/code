    var root = (JObject) JsonConvert.DeserializeObject(json);
    var brands = root["Brands"]
      .AsJEnumerable()
      .First()
      .AsJEnumerable()
      .Cast<JProperty>()
      .ToDictionary(j => j.Name, j => j.Value);
