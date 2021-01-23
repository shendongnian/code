    public void UpdateTable(int month, int year)
    {
        // Code here.
    }
    public void UpdateTable(int month)
    {
        // fill in the current year
        UpdateTable(month, DateTime.Now.Year);
    }
    public void UpdateTable()
    {
        // fill in the current month / year
        UpdateTable(DateTime.Now.Month, DateTime.Now.Year);
    }
