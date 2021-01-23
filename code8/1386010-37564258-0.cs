     IQueryable<EventsViewModel> theevent = (
             from v in datacontext
             where v.event_start == null
             select new EventsViewModel
             {
                 event_idx = v.event_idx,
                 event_name = v.event_name
                 organiser_info = v.event_organiser + ' ' + DatePart("dd", v.event_start)
             });
Other option is to include all needed columns and extend your EventsViewModel with a getter property:
    public class EventsViewModel
    {
        ...
        public string organiser_info 
        {
            get
            {
                return string.format("{0} {1} / {2}", 
                    event_organiser,
                    event_start.ToString("dd"),
                    event_end.ToString("MM"))
            }
        }
    }
