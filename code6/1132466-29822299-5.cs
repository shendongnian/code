    private async Task<BatchResult> FetchBatches()
    {
        var result = new List<BatchResult>();
        var taskList = new List<Task<BatchResult>>();
        for (var i = 0; i < _batchesList.Count; ++i)
        {
            var localI = i;
            var batch = _batchesList[localI];
            taskList.Add(new Task(() => batch.Fetch())); //this is calling the external services
            if (localI < _batchesList.Count - 1)
            {
                taskList[localI].ContinueWith(t => 
                {
                    // handle Exception here
                    result.Add(t.Result);
                    taskList[localI + 1].Start();
                });
            }
        }
        if (_batchesList.Count > 0)
        {
            await taskList[0];
        }
        return result;
    }
