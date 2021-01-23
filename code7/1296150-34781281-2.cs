    List<aoitime> offlineItems = <some method that produces this list>
    List<aoitime> onlineItems = <some method that produces this list>
    List<aoitime> attendanceItems = new List<aoitime>();
    //For simplicity, assuming that you have the same number of elements in each list
    for (int i = 0; i < offlineItems.Count; i++)
    {
        aoitime offline = offlineItems[i];
        aoitime online = onlineItems[i];
        if(offline.ID == online.ID && offline.DateWithoutSlashes = online.DateWithoutSlashes)
        {
            //Create your new object and add it to the attendance items collection.
        }
        else
        {
            //Process the exceptions and add them individually to the attendance items collection.
        }
    }
