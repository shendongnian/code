    List<Photo> list = new List<Photo>();
    var distinctTags = list.SelectMany(r => r.Tags).Distinct();
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    foreach (string tag in distinctTags)
    {
        dictionary.Add(tag, list.Count(r=> r.Tags.Contains(tag)));
    }
