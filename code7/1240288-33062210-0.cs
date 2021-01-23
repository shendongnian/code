    var wordCountList = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .GroupBy(messagestr => messagestr)
        .OrderByDescending(grp => grp.Count())
        .Take(20) //or take the whole
        .Select(grp => new KeyValuePair<string, int>(grp.Key, grp.Count()))
        .ToList(); //return wordCountList
    //usage
    wordCountList.ForEach(item => Console.WriteLine("{0}\t{1}", item.Key, item.Value));
