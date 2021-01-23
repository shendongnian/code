    var items = GetItemList().Select(x => x.SomeStringPropertyOnSingleSignerTable)
                             .Distinct()
                             .ToList();
    foreach (string option in items)
    {
        lField.Items.Add(option);
    };
