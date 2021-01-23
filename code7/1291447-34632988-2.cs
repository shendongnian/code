    @{
    foreach (var item in Model)
    {
        createMenuItem(item);
    }
    }
    @helper createMenuItem(Navbar item)
    {
    if (item.Children.Any())
    {
        foreach (var child in item.Children)
        {
            createMenuItem(child);
        }
    }
    <li>...</li>
    }
