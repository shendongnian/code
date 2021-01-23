    public object MoveLoopToBottom()
    {
        if (selectedLoops.Count < 1)
            return null;
        foreach (ProfilerLoop selected in selectedLoops)
        {
            int moveFrom = PartLoops.IndexOf(selected);
            ClonedLoops.Move(moveFrom, PartLoops.Count - 1);
        }
        return null;
    }
