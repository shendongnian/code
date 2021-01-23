    private void ApplyPrivilegeUpdateClick(object sender, RoutedEventArgs e)
    {
        var newPrivilegeModel = new Dictionary<string,int>();
        int i = 0;
        foreach (CheckBox c in companiesTabItem)
        {
            if (c.IsChecked == true)
            {
                if(newPrivilegeModel.ContainstKey("Priv"+(i + 1).ToString())){
                  newPrivilegeModel["Priv"+(i + 1).ToString()]=1;
                }
                else
                {
                  newPrivilegeModel.Add("Priv"+(i + 1).ToString(),1);
                }
            }
            i++;
        }
    }
