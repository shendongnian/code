    public bool IsValidTimeFormat(string input)
    {
        TimeSpan dummyOutput;
        return TimeSpan.TryParse(input, out dummyOutput);
    }
