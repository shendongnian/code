    /// <summary>
    /// This will take a piece of XML, and replace the value of a node with a new value. i.e. Use Linq To XML to change XML values.
    /// </summary>
    /// <param name="xml">The xml to update</param>
    /// <param name="nodeToUpdate">The nodes or series of nodes the you wish to update the value of</param>
    /// <param name="newValue">The new value of the node</param>
    /// <returns>The new xml string</returns>
    public string ReplaceProductCodeInXML(string xml, string nodeToUpdate, string newValue)
    {
      // Load our xml into a format we can do LINQ to XML on
      XElement root = XElement.Load((new StringReader(xml)), LoadOptions.None);
    
      // Look for all descendants where the node matches the one we want and update all the values to what we want
      // E.g. Get Node "product_name" -> and set its value to newValue.
      root.Descendants().Where(i => i.Name.LocalName == nodeToUpdate)
    	.ToList()
    	.ForEach(i => i.ReplaceNodes(newValue));
    
      return root.ToString();
    }
