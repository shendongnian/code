    foreach (var item in objects)
    {
        var props = item.GetType().GetProperties();
        var assetProperty = props.FirstOrDefault(p => p.Name == "Asset");
        if (assetProperty != null)
        {
            var value = assetProperty.GetValue(item, null);
            // Do stuff...
        }
    }
