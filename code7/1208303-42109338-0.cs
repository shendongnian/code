    foreach (Control c in FilterRepeater.Controls)
    {
        var dynamicFilter = c.Controls.OfType<DynamicFilter>().FirstOrDefault();
        if (dynamicFilter == null)
            continue;
        QueryableFilterUserControl filterTemplate = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
        if (filterTemplate == null)
            continue;
        WebControl filterControl = filterTemplate.FilterControl as WebControl;
        if (filterControl == null)
            continue;
        //now we have access to the filter control
        filterControl.Enabled = false; 
    }
