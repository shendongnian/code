    public void RegisterTime(TimeSpan time)
    {
        TimeSpent += time;
        // maybe more stuff here
        Parent.RegisterTime(time)
    }
