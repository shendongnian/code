    private void ConsumerTask(object parameter) 
    {
        var localPendingEntries = (BlockingCollection<List<Entry>>)parameter;
        foreach (var entry in localPendingEntries.GetConsumingEnumerable())
        {
           // push the 'entry' where you want.
        }
    }
