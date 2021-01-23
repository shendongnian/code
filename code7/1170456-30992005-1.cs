    [Serializable]
    public class HistoryRoot
    {
        public HistoryList
        Files = new HistoryList
        {
            sl = new SortedList<DateTime, string>(),
            //list = new List<HistoryItem>(),   <-- Remove this line
            max = 500,
            c = program.M.qFile
        },
        Folders = new HistoryList
        {
            sl = new SortedList<DateTime, string>(),
            //list = new List<HistoryItem>(),   <-- Remove this line
            max = 100,
            c = program.M.qFolder
        },
    }
