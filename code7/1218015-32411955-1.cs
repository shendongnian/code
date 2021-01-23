    foreach (XmlNode subCollection in xml.SelectNodes(
     "//Collection[@name='CORALL']/SubCollection[Column[@name='EX_ID' and starts-with(., 'h')] and Column[@name='AMT'   and . = '0.00']]"))
    {
        // SubCollection.Collection.RemoveChild(SubCollection)
        subCollection.ParentNode.RemoveChild(subCollection);
    }
