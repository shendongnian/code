    public static TimeSpan SaferTimeSpanParse(string input, char delimiter = ':')
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException("input must not be null or empty", "input");
        string[] tokens = input.Split(delimiter);
        if (tokens.Length < 2 || tokens.Length > 3)
            throw new NotSupportedException("Timespan could not be parsed successfully: " + input);
        int i;
        if (!tokens.All(t => int.TryParse(t, out i) && i >= 0)) 
            throw new ArgumentException("All token must contain a positive integer", "input");
        int[] all = tokens.Select(t => int.Parse(t)).ToArray();
        int hours = 0, minutes = 0, seconds = 0;
        for (i = all.Length - 1; i >= 0; i--)
        {
            if (i == all.Length - 1)// last means seconds
            { 
                int secs = all[i];
                if(secs <= 59)
                    seconds = secs;
                else
                {
                    // "repair" seconds by adding multiples of 60 to the minutes:
                    seconds = secs % 60;
                    minutes = secs / 60;
                }
            }
            else if (i == 1 || all.Length == 2) // means either middle of three tokens or at the beginning of two -> minutes
            {
                int mins = all[i] + minutes; // add current minutes which might already be increased through seconds
                if (mins <= 59)
                    minutes = mins;
                else
                {
                    // "repair" minutes  by adding multiples of 60 to the hours:
                    minutes = mins % 60;
                    hours = mins / 60;
                }
            }
            else // means beginning 
            {
                if (all.Length == 3) // including hours
                {
                    hours = all[0] + hours; // add current hours which might already be increased through minutes
                }
            }
        }
        return new TimeSpan(hours, minutes, seconds);
    }
