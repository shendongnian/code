    private Action<TypeItem>[] _longTasks = new Action<TypeItem>[]
    // Not sure about the type
    // that could be also something like Func<TypeItem, Task>
        {
            LongTask1,
            LongTask2,
            LongTask3,
            LongTask4,
            LongTask5
        };
    public async Task Process(CancellationTokenSource token)
    {
        await SpinUpServiceAsync();
        foreach (var item in LongList())
            foreach (var longTask in _longTasks)
            {
                if (token.IsCancellationRequested)
                    return Cancel(item);
                await longTask(item);
            }
    }
    private async Task Cancel(TypeItem item)
    {
        Log($"Cancelled during {item}");
        await SpinDownServiceAsync();
    }
