    public class Item
    {
        public string Name { get; set; }
        public DateTime ItemDate { get; set; }
    }
    public class ItemWithWeekInfo
    {
        public int Year { get; set; }
        public int WeekOfTheYear { get; set; }
        public Item Item { get; set; }
    }
    
    public class Order
    {
        public int Year { get; set; }
        public int WeekOfTheYear { get; set; }
        public List<Item> Items { get; set; }
    }
    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    Calendar cal = dfi.Calendar;
    var groups =  items.Select(p => new ItemWithWeekInfo
            {
                Year = p.ItemDate.Year,
                WeekOfTheYear = cal.GetWeekOfYear(p.ItemDate, dfi.CalendarWeekRule, DayOfWeek.Monday),
                Item = p
            }).GroupBy(p => new { p.Year , p.WeekOfTheYear}).Select(p=>new Order
            {
                Year = p.Key.Year,
                WeekOfTheYear = p.Key.WeekOfTheYear,
                Items = p.Select(x=> x.Item).ToList()
            }).ToList();
