    public List<DateTime> GetDates()
    {
        IEnumerable<DateTime> MyDates = GetAllMyDates();
        IEnumerable<DateTime> ModifiedDates = null;
        if (MyDates != null && MyDates.Count() > 0)
        {
            AllDates = MyDates.Where(....Some filter)
            return AllDates.ToList();
        }
        return null;
    }
