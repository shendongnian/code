    public enum EventTypes
    {
        Birthday,
        Anniversary
    }
    public class Event
    {
        public string Date { get; set; }
        public EventTypes Type { get; set; }
        public IEnumerable<dynamic> Items { get; set; }
    }
	
	var result = FinalList.SelectMany(item => new List<dynamic>
							{
								new { Date = item.Birthday.ToString("ddMM"), Type = EventTypes.Birthday, Item = item },
								new { Date = item.Anniversary.ToString("ddMM"), Type = EventTypes.Anniversary, Item = item }
							})
						  .GroupBy(item => new { item.Date, item.Type })
						  .Select(grouping => new Event { Date = grouping.Key.Date, Type = grouping.Key.Type, Items = grouping.ToList() }).ToList();
