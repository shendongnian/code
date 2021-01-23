    foreach (var item in doc.Descendants("POS_STOREITEM")
    {
        var dictionary = item.Descendants()
            .ToDictionary(e => e.Name.ToString(), e => e.Value);
        // do something with dictionary
    }
