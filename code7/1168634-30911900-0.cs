    if (c.GetType() == typeof(System.Web.UI.Webcontrols.ListItem))
    {
        string id = c.ID;
        string value = ((System.Web.UI.Webcontrols.ListItem)(c)).Value;
    }
