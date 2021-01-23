        var classNameTasks = Enumerable.Range(1, 200)
            .Select(i => webApi.getSplittedClassName())
            .ToArray();
        wordList.AddRange(
            Task.WhenAll(classNameTasks).Result
                .SelectMany(g => g));
