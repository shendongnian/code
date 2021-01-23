    PropertySet MyPropSet = new PropertySet(BasePropertySet.FirstClassProperties);
    MyPropSet.Add(MyCustomProp);
    CalendarFolder = CalendarFolder.Bind(service, new FolderId(WellKnownFolderName.Calendar, "mailbox@domain.com"),MyPropSet);
    Object PropValue = null;
    if (CalendarFolder.TryGetProperty(MyCustomProp, out PropValue)) 
    {
        Console.WriteLine(PropValue);
    }
