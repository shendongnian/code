    public void Merge(Latest value)
    {
        if (value != null)
        {
            if ((value.latestDateTime < latestDateTime) || (latestDateTime.IsNull))
            {
                latestValue = value.latestValue;
                latestDateTime = value.latestDateTime;
            }
        }
    }
