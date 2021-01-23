    ...
    List<string> itemsForAdding = // some items that needs to be added
        
    // check if dictionary has the key
    if (m_ColumnAssociations.ContainsKey(item.Text)) 
    {
        var listFromDictionary = m_ColumnAssociations[item.Text];
    
        // add the whole list
        listFromDictionary.AddRange(itemsForAdding);
    
        // remove the duplicates from the list and save it back to dictionary
        m_ColumnAssociations[item.Text] = listFromDictionary.Distinct();
    }
    ...
