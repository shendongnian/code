    int totalCount = returnedCol.total_count;
    var tasks = Enumerable.Range(1, totalCount / pageSize)
        .Select(async page => {
            await Task.Delay(page * 100);
            return ExternalCall.GetData(page, pageSize));
        })
        .ToArray();
    myDict = (await Task.WhenAll(tasks))
        .ToDictionary(dataiwant => dataiwant.id);
