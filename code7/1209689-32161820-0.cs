    public static List<dynamic> GetDonutSeries(this Polls p)
    {
        List<dynamic> result = new List<dynamic>();
        foreach (PollOptions po in p.PollOptions)
        {
            result.Add(new { category = po.OptionName, value = po.PollVotes.Count });
        }
        return result;
    }
