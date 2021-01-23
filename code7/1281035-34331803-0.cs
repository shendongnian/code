    string s1 = "Apple, Mango, Cherry";
    string s2 = "Apple, Mango, Cherry, Pear";
    List<string> list1 = s1.Split(',').Select(s => s.Trim()).ToList();
    List<string> list2 = s2.Split(',').Select(s => s.Trim()).ToList();
    
    var res = list2.Count > list1.Count ? list2.Where(s => !list1.Contains(s)).ToList() :
                                          list1.Where(s => !list2.Contains(s)).ToList();
