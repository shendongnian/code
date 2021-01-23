    foreach (var item in objects)
    {
        var assetProperty = item.GetType().GetProperty("Asset");
        if (assetProperty != null)
        {
            var value = assetProperty.GetValue(item, null);
            // Do stuff...
        }
    }
