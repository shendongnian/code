    <#=codeStringGenerator.NavigationProperty(navigationProperty).Replace(tablePerfix,"")#>
---
    foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>
    (itemCollection))
    {
        fileManager.StartNewFile(entity.Name + ".cs");
        BeginNamespace(code);
    #>
