    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FullName
    {
        get
        {
            return LastName + " " FirstName;
        }
        series
        {
            var nameParts = value.Split(' ');
            LastName = string.IsNullOrEmpty(nameParts[0]) ? string.Empty : nameParts[0];
            FirstName = string.IsNullOrEmpty(nameParts[1]) ? string.Empty : nameParts[1];
        }
    }
