    public void UpdateTable(int month, int year)
    {
        // Code here.
    }
    public void UpdateTable(int month)
    {
        UpdateTable(month, DateTime.Now.Year);
    }
    public void UpdateTable()
    {
        UpdateTable(DateTime.Now.Month, DateTime.Now.Year);
    }
