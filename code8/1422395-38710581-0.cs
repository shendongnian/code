    static void GetCalendarItem(ExchangeService svc, string iCalUid)
    {
        var view = new ItemView(500);
        var propSet = new PropertySet(BasePropertySet.IdOnly);
        propSet.Add(ItemSchema.Subject);
        propSet.Add(MeetingMessageSchema.ICalUid);
        view.PropertySet = propSet;
        var items = svc.FindItems(WellKnownFolderName.Calendar, view);
        foreach (var item in items)
        {
            var subject = item.Subject;
            var result = item.ICalUid;
            Console.WriteLine("Sub: {0}, Result: {1}", subject, result);
        }
    }
