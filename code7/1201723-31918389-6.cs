    for (int i = 0; i < checklistbox.Items.Count; i++)
    {
        checklistbox.SetItemChecked(i, IsValueExist(onlineVaults, checklistbox.Items[i]));            
    }
    
    private bool IsValueExist(List<string> list, string value)
    {
        return list.Any(x => string.Compare(x.Trim(), value.Trim(), StringComparison.InvariantCultureIgnoreCase) == 0);        
    }
