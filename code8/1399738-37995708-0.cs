    public string ReturnEndDateForDisplay {
    get
    {
        return this.EndDate.HasValue? this.EndDate.Value.ToString("d"):"";
    }
