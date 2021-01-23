    ...
    SPWeb spWeb = properties.Web;
    SPListTemplateType type = new SPListTemplateType();
    type = SPListTemplateType.Events;
    EventFiringEnabled = false;  // Disable event firing and create the list
    Guid listGuid = spWeb.Lists.Add(calendarTitle, "Associated Calendar", type);
    SPList newList = spWeb.Lists[listGuid];
    newList.OnQuickLaunch = properties.List.OnQuickLaunch;
    newList.Update();
    EventFiringEnabled = true;  // Re-enable event firing
    ...
