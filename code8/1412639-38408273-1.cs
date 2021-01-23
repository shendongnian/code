    private class BookInfo {
        string title {get;set;}
        string person {get;set;}
        List<int> pages {get;set;}
    }
    
    private List<BookInfo> allbooks = new List<BookInfo>();
    public void parse() {
        var lines = File.ReadAllLines(filename);  //you could also read the file line by line here to avoid reading the complete file into memory
        foreach (var l in lines) {
           var info = l.Split(',').Select(x=>x.Trim()).ToArray();
           var b = new BookInfo {
              title = info[0],
              person = info[1]+", " + info[2],
              pages = info.Skip(3).Select(x=> int.Parse(x)).ToList()
           };
           allbooks.Add(b);
        }
    }
