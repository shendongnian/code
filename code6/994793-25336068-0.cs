    private static void CalculateTimeIntervals()
        {
            var startTime = new DateTime(2014, 8, 15, 8, 0, 0);
            var endTime = new DateTime(2014, 8, 15, 17, 0, 0);
            var lengthOfTime = endTime - startTime;
            var numberOfPeople = 4;
            var dividedLengthOfTime = lengthOfTime.Ticks / numberOfPeople;
            var people = new List<Person>();
            for (int i = 1; i <= numberOfPeople; i++)
            {
                people.Add(
                    new Person
                    {
                        Id = i,
                        StartTime = startTime.AddTicks((dividedLengthOfTime * i) - dividedLengthOfTime),
                        EndTime = startTime.AddTicks(dividedLengthOfTime * i)
                    });
            }
        }
