        var set = new SortedSet<DateTime>();
        var time = DateTime.Now;
        //2 sample values to test with
        set.Add(time.AddHours(1));
        set.Add(time.AddHours(-1));
        //We temporarily add our time to the set
        set.Add(time);
        var next = set.SkipWhile(a => !a.Equals(time)).Skip(1).FirstOrDefault();
        var previous = set.Reverse().SkipWhile(a => !a.Equals(time)).Skip(1).FirstOrDefault();
        //and remove it in the end 
        set.Remove(time);
