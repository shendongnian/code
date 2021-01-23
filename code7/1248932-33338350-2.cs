    string[] Main_Events = { "Five Ships In The Harbour", "Australia Day", "Christmas", "New Years", "The Melbourne Cup", "Australian Open Tennis" };
    string search_str = "The Australia Day";
    List<string> search_strs = search_str.Split(null).Where(s => s != string.Empty).ToList();
    if (search_strs.Count > 0)
    {                  
        List<string> searchResult = Main_Events.Where(x => search_strs.Any(keyword => (x).Contains(keyword))).ToList();                                                                   
    }
