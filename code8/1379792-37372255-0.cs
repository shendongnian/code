    public static void UpArrow()
    {
        historySelected = Math.Max(0, historySelected - 1);
        current = cmdHistory[historySelected];
    }
    public static void DownArrow()
    {
        var maxIndex = cmdHistory.Count - 1;
        historySelected = Math.Min(maxIndex, historySelected + 1);
        current = cmdHistory[historySelected];
    }
