    public IEnumerable<DateTime> GenerateRandomDates(int numberOfDates)
    {
        var rnd = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < numberOfDates; i++)
        {
            var year = rnd.Next(1, 10000);
            var month = rnd.Next(1, 13);
            var days = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
            yield return new DateTime(year, month, days,
                rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60), rnd.Next(0, 1000));
        }
    }
