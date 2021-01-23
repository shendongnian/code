     public string CreateUpdateEvent(string ExpKey, string ExpVal, string evTitle, string evDate)
        {
            EventsResource er = new EventsResource(calService);
            var queryEvent = er.List(calID);
            queryEvent.SharedExtendedProperty = ExpKey + "=" + ExpVal; //"EventKey=9999"
            var EventsList = queryEvent.Execute();
    
            Event ev = new Event();
            EventDateTime StartDate = new EventDateTime();
            StartDate.Date = evDate; //"2014-11-17";
            EventDateTime EndDate = new EventDateTime();
            EndDate.Date = evDate;
    
            ev.Start = StartDate;
            ev.End = EndDate;
            ev.Summary = evTitle; //"My Google Calendar V3 Event!";
    
            string FoundEventID = String.Empty;
            foreach(var evItem in EventsList.Items)
            {
                FoundEventID = evItem.Id;
            }
    
            if (String.IsNullOrEmpty(FoundEventID))
            {
                //If event does not exist, Append Extended Property and create the event
                Event.ExtendedPropertiesData exp = new Event.ExtendedPropertiesData();
                exp.Shared = new Dictionary<string, string>();
                exp.Shared.Add(ExpKey, ExpVal);
                ev.ExtendedProperties = exp;
                return er.Insert(ev, calID).Execute().Summary;
            }
            else
            {
                //If existing, Update the event
                return er.Update(ev, calID, FoundEventID).Execute().Summary;
            }
        }
