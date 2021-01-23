    public List<Tuple<DateTime,DateTime>> GetStartsAndEndsOfWeeks(int numOfWeeks, int getDay, DateTime now)
    {
        var list = new List<Tuple<DateTime,DateTime>>();
        for(int i = 0, i < numOfWeek, i++)
        {
            list.Add(new Tuple {
               Item1 =   GetStartOfWeek(now, getDay, i),
               Item2 =   GetEndOfWeek(now, getDay, i),
             });
        }
        return list;
    }
