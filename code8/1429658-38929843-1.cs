    public bool DeleteEvent(string ExpKey, string ExpVal)
        {
            EventsResource er = new EventsResource(calService);
            var queryEvent = er.List(calID);
    
            queryEvent.SharedExtendedProperty = ExpKey + "=" + ExpVal; //"EventKey=9999"
            var EventsList = queryEvent.Execute();
    
            string FoundEventID = String.Empty;
            foreach (Event ev in EventsList.Items)
            {
                FoundEventID = ev.Id;
                er.Delete(calID, FoundEventID).Execute();
                return true;
            }
    
            return false;
        }
