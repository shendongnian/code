    int arrayIndex = 0;
    ConcurrentDictionary<string,int> customModel
            = new ConcurrentDictionary<string,int>();
    Parallel.ForEach<EmployeeHolidaysModel>(
        holidays,
        new ParallelOptions() {
            MaxDegreeOfParallelism = System.Enviroment.ProcessorCount
        },
        item => customModel.TryAdd(
            item.HolidayName,
            Interlocked.Increment(ref arrayIndex)
        )
    );
    NowYouCanDoSomethingWith(customModel);
