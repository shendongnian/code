    public void Output(IEnumerable<XElement> nodes, int depth)
    {
    	foreach(var node in nodes)
    	{
    		Console.WriteLine(new string('\t', depth) + node.Element("nodeName").Value);
    		Output(node.Elements("node"), depth + 1);
    	}
    }
