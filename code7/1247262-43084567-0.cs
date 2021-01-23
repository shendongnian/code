    var eventsUri = CalendarContract.Events.ContentUri;
    string[] eventsProjection = {
    				CalendarContract.Events.InterfaceConsts.Id,
    				CalendarContract.Events.InterfaceConsts.Title,
    				CalendarContract.Events.InterfaceConsts.Dtstart,
    				CalendarContract.Events.InterfaceConsts.Description
    			 };
    string selection = CalendarContract.Events.InterfaceConsts.Dtstart + " >= ? AND " + CalendarContract.Events.InterfaceConsts.Dtstart + "<= ?";
    string[] sourceColumns = {
    					CalendarContract.Events.InterfaceConsts.Title,
    					CalendarContract.Events.InterfaceConsts.Dtstart
    				};
    int[] targetResources = { Resource.Id.eventTitle, Resource.Id.eventStartDate };
    var adapter = new SimpleCursorAdapter(context, Resource.Layout.EventListItem, cursor, sourceColumns, targetResources);
    adapter.ViewBinder = new ViewBinder();
    listview.Adapter = adapter;
