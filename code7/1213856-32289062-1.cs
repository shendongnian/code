    @{
        List<string> EventTypeList= ViewData["EventType"] as List<string>;
        if (EventTypeList != null && EventTypeList.Count > 0){
            foreach (string eventType in EventTypeList)
            {
                <li><a> <span class="pull-right">eventType</span></a></li>
            }
        }
    }
