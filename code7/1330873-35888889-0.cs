     protected List<Week> getList(int count, int getDay)
    {
        var list = new List<Week>();
        DateTime now = DateTime.Now;
        for (int n = 0; n < count; n++)
        {
            Week w = new Week();
            w.Start = now.AddDays((-(int)now.DayOfWeek + 1) - getDay - n * 7);
            w.End = now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6 - n * 7);
            list.Add(w);
        }
        return list;
    }
    public class Week{    public DateTime Start { get; set; }    public DateTime nd { get; set; }}
