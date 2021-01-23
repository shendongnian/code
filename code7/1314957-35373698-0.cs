    string searchPattern = "384";
    List<string> sNumbers = new List<string> { "34521", "38450", "138477", "38451", "28384", "13841", "12345" };
            
    var list1 = sNumbers.Where(s => s.StartsWith(searchPattern)).OrderBy(s => s).ToList();
    var list2 = sNumbers.Where(s => !s.StartsWith(searchPattern) && s.Contains(searchPattern)).OrderBy(s => s).ToList();
    var outputList = new List<string>();
    outputList.AddRange(list1);
    outputList.AddRange(list2);
