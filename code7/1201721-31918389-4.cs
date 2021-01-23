    for (int i = 0; i < checklistbox.Items.Count; i++)
    {
        checklistbox.SetItemChecked(i, IsValueExist(onlineVaults, checklistbox.Items[i]));            
    }
    
    private bool IsValueExist(List<string> list, string value)
    {
        foreach (var item in list)
        {
            if (string.Compare(item.Trim(), value.Trim(), StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                 return true;
            }
        }
        return false;
    }
