    List<NewsTag> list = new List<NewsTag>();
    	list.Add(new NewsTag());
    	list.Add(NewsTag);
    	list.Add(NewsTag);
    	list.Add(NewsTag);
    	
    	List<string> names = "One,Two,Three,Four".Split(',').ToList<string>();
    	
    	for (var i = 0; i < names.Count; i++) {
        list[i].Name = names[i];
    }
