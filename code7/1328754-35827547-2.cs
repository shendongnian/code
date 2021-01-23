    string[] Collection1 = {"I am good", "He is best", "They are poor", "Mostly they are average", "All are very nice"};
    string[] Collection2 = { "good", "best", "nice" };
    
    Collection2 = Collection2.Select(x => x.ToLower()).ToArray();
    
    var Collection3 = Collection1.Select(x => x.ToLower())
                       .Where(x => Collection2.All(y => x.Contains(y))).ToArray();
