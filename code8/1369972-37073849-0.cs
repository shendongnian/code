    var checkedItems = listViewColumns.CheckedItems;
    if (checkedItems != null)
    {
        foreach (ListViewItem item in checkedItems)
        {
            List<string> itemsForAdding = // some items that needs to be added
    
            // check if dictionary has the key
            if (m_ColumnAssociations.ContainsKey(item.Text)) 
            {
                var listFromDictionary = m_ColumnAssociations[item.Text];
    
                foreach(var itemForAdding in itemsForAdding)
                {
                    if(!listFromDictionary.Contains(itemForAdding)
                    {
                        listFromDictionary.Add(itemForAdding);
                    }
                }
            }
        }
    }
