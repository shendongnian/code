    Array values = Enum.GetValues(typeof(ValueEnum));
    List<ListItem> items = new List<ListItem>(values.Length);
        foreach(var i in values)
        {
            items.Add(new ListItem
            {
                Text = Enum.GetName(typeof(ValueEnum), i),
                Value = ((int)i).ToString()
            });
        }
        ViewBag.valueEnum = new SelectList(items);
