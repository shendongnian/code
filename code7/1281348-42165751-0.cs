    string fileName = this.Host.ResolvePath("MyResource.resx");
    ResXResourceReader reader = new ResXResourceReader(fileName);
    // This lets you access the comment. If set to false the DictionaryEntry's
    // value will simply be the resource value.
    reader.UseResXDataNodes = true;
    foreach (DictionaryEntry resource in reader)
    {
        ResXDataNode node = (ResXDataNode)resource.Value;
        string key = (string)resource.Key;
        string value = (string)node.GetValue((ITypeResolutionService)null);
        string comment = node.Comment;
    }
