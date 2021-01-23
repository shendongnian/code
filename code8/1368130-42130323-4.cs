    foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>
    (itemCollection))
    {
        fileManager.StartNewFile(entity.Name.Replace(tablePerfix,"") + ".cs");
        BeginNamespace(code);
