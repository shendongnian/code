     public class Period
        {
            public List<Week> Weeks { get; private set; }
    
            public Period(Week week)
            {
                Weeks = new List<Week>(new[]{week});
            }
    
            public bool AddWeek(Week week)
            {
                if (!Weeks.First().AreAlike(week))
                {
                    return false;
                }
                Weeks.Add(week);
                return true;
            }
    
            public DateTime StartDate 
            {
                get { return Weeks.First().StartDate; }
            }
    
            public DateTime EndDate
            {
                get { return Weeks.Last().EndDate; }
            }
    
            public Dictionary<DayOfWeek, bool> Display
            {
                get { return Weeks.First().Days.ToDictionary(d => d.Key.DayOfWeek, d => d.Value); }
                
            }
        }
