    public class EventBooking
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    
    public ActionResult CreateDDL()
    {
        var eventList = new List<EventBooking>();
        EventBooking eventItem;
        var eventArr = new string[] { "Event-1", "Event-2", "Event-3", "Event-4", "Event-5", "Event-6", "Event-7" };
        for (int index = 0; index < eventArr.Length; index++)
        {
            eventItem = new EventBooking();
            eventItem.Id = index + 1;
            eventItem.Name = eventArr[index];
            eventList.Add(eventItem);
        }
        ViewBag.EventList = eventList;
    
        return View();
    }
