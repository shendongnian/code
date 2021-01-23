    public List<userHistory> lstUserHistory { get; set; }
    public userHistory(string timedate, string url)
    {
        lstUserHistory.Add(new userHistory(timedate, url));
    }
