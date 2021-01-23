    List<int> xHistoy = new List<int>(); // Or Queue<int>
    int x;
    private int AssignWithHistory(int val)
    {
        xHistory.Add(val);
        return x;
    }
    x = AssignWithHistory(0);
    x = AssignWithHistory(5);
    x = AssignWithHistory(10);
