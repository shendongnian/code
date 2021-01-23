    private IEnumerable<Day> CreateDaysData()
    {
        var maxDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        for (int d = 1; d <= maxDays; d++)
        {
            var day = new Day
            {
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, d)
            };
            var viewSource = new CollectionViewSource
            {
                Source = ScenesCollection
            };
            viewSource.Filter += new FilterEventHandler((o, e) =>
            {
                e.Accepted = (e.Item as Scene).Date == day.Date;
            });
            day.Scenes = viewSource.View;
            yield return day;
        }
    }
