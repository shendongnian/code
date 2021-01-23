    public static List<Day> Check(List<Day> days) {
        if (days.First().IsActive || days.Last().IsActive) {
            var daysInBetween = days.Take(days.Count - 1).Skip(1);
            return Check(daysInBetween);
        }
        else
            return days;
    }
