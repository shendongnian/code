    var reader = new ResXResourceReader("filename");
    var node = reader.GetEnumerator();
    var writer = new ResXResourceWriter("filename");
    while (node.MoveNext())
    {
        writer.AddResource(node.Key.ToString(), node.Value.ToString());
    }
    var newNode = new ResXDataNode("name", "value");
    writer.AddResource(newNode);
    writer.Generate();
    writer.Close();
