    // Store your FlowDocument as a list of strings
    List<string> blocksAsStrings = FlowDoc_store(_docSelected._Rtb.Document);
    ...
    // Load your FlowDocument into your RichTextBox
    rtb.Document = FlowDoc_load(blocksAsStrings);
    
    /// <summary>
    /// Stores a FlowDocument as a list of strings, each string represents a Block.
    /// </summary>
    public static List<string> FlowDoc_store(FlowDocument flowDoc)
    {
    	List<string> blocksAsStrings = new List<string>(flowDoc.Blocks.Count);
    
    	foreach (Block block in flowDoc.Blocks)
    	{
    		blocksAsStrings.Add(XamlWriter.Save(block));
    	}
    
    	return blocksAsStrings;
    }
    
    /// <summary>
    /// Loads a FlowDocument from a list of strings, each string represents a Block.
    /// </summary>
    public static FlowDocument FlowDoc_load(List<string> blocksAsStrings)
    {
    	FlowDocument flowDoc = new FlowDocument();
    
        foreach (string blockAsString in blocksAsStrings)
        {
            using (StringReader stringReader = new StringReader(blockAsString))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader))
                {
                    Block block = (Block)XamlReader.Load(xmlReader);
                    flowDoc.Blocks.Add(block);
                }
            }
        }
    	return flowDoc;
    }
