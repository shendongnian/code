    public List<string> getListItems()
    {
       return listBox1.Items.Cast<object>()
                            .Select(x => x.ToString())
                            .ToList();
    }
