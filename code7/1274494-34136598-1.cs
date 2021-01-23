    List<string> list;
    if (!providerLevelChanges.TryGetValue("someKey", out list))
    {
        list = new List<string>();
        providerLevelChanges.Add("someKey", list);
    }
    list.Add("someNewValue");
