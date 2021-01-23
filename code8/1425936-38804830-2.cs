    List<string> mylist = new List<string>();
    mylist.Add("book is good ");
    mylist.Add("i like flowers ");
    mylist.Add("i reading book");
    
    var mostRepeatedWord = mylist.SelectMany(x => x.Split(new [] { " " }, 
                                                 StringSplitOptions.RemoveEmptyEntries))
                                 .GroupBy(x => x).OrderByDescending(x => x.Count())
                                 .Select(x => x.Key).FirstOrDefault();
