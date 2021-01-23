    var temp =  JArray.Parse(json);
    temp.Descendants()
        .OfType<JProperty>()
        .Where(t => t.Name.StartsWith("_umb_")
        .ToList() // you should call ToList because you're about to changing the result, which is not possible if it is IEnumerable
        .ForEach(attribute => attribute.Remove()); // removing unwanted attributes
    json = temp.ToString(); // backing result to json
