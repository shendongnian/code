    /// <summary>
    /// returns the elementwrappers that are identified by the Object_ID's returned by the given query
    /// </summary>
    /// <param name="sqlQuery">query returning the Object_ID's</param>
    /// <returns>elementwrappers returned by the query</returns>
    public List<ElementWrapper> getElementWrappersByQuery(string sqlQuery)
    {
      // get the nodes with the name "ObjectID"
      XmlDocument xmlObjectIDs = this.SQLQuery(sqlQuery);
      XmlNodeList objectIDNodes = xmlObjectIDs.SelectNodes(formatXPath("//Object_ID"));
      List<ElementWrapper> elements = new List<ElementWrapper>();
      
      foreach( XmlNode objectIDNode in objectIDNodes ) 
      {
      	ElementWrapper element = this.getElementWrapperByID(int.Parse(objectIDNode.InnerText));
        if (element != null)
        {
        	elements.Add(element);
        }
      }
      return elements;
    }
