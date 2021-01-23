    var temp =  JArray.Parse(json);
    temp.Descendants()
        .OfType<JProperty>()
        .Where(attr => attr.Name.StartsWith("_umb_"))
        .ToList() // you should call ToList because you're about to changing the result, which is not possible if it is IEnumerable
        .ForEach(attr => attr.Remove()); // removing unwanted attributes
    json = temp.ToString(); // backing result to json
