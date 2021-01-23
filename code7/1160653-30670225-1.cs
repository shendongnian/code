    public class EventEntityRepo
    {
        public EventEntity GetEventEntityByCsvDataRow(String[] csvRow)
        {
            EventEntity events = new EventEntity();
            foreach (String csvCell in csvRow)
            {
                int eventId = -1;
                if(csvCell != null && csvCell != String.Empty)
                {
                    try
                    {
                        eventId = Convert.ToInt32(csvCell.Trim());
                    }
                    catch (Exception ex)
                    {
                        //failed to parse int
                    }
                }
                events.EventList.Add(eventId); //if an empty item, insert -1
            }
            return events;
        }
    }
