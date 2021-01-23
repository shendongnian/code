    protected RibbonEditItemBase getbyName(string name, ASPxRibbon ribbon)
    {
        foreach (RibbonTab tab in ribbon.Tabs)
            foreach (RibbonGroup group in tab.Groups)
                foreach (RibbonItemBase item in group.Items)
                {
                    var edit = item as RibbonEditItemBase;
                    if (edit != null && edit.Name == name)
                        return edit;
                }
        return null; //not found, return null
    }
