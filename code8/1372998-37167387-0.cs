    int totalCount = returnedCol.total_count;
    var tasks = Enumerable.Range(1, totalCount / pageSize)
        .Select(async page => {
            await Task.Delay(pageNumer * 100);
            return ExternalCall.GetData(pageNumber, pageSize));
        })
        .ToArray();
    myDict = (await Task.WhenAll(tasks))
        .ToDictionary(dataiwant => dataiwant.id);
