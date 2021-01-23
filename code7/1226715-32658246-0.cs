    private IEnumerable<string> GetValues(bool selected)
    {
       var vName = selected ? "SelectedValues" : "UnSelectedValues";
       if (ViewState[vName] == null && chapp.SelectedIndex >= -1)
       {
          ViewState[vName] = chapp.Items.Cast<ListItem>()
                        .Where(x => x.Selected == selected)
                        .Select(x => x.Value).ToList();
       }
       else
       {
          ViewState[vName] = Enumerable.Empty<string>();
       }
       return (IEnumerable<string>)ViewState[vName];
    }
