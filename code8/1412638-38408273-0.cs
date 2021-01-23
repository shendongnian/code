    private class BookInfo {
        string title {get;set;}
        string author {get;set;}
        int i1 {get;set;}  //don't know what these nubmers are
        int i2 {get;set;}
        int i3 {get;set;}
    }
    
    private List<BookInfo> allbooks = new List<BookInfo>();
    public void parse() {
        var lines = File.ReadAllLines(filename);  //you could also read the file line by line here to avoid reading the complete file into memory
        foreach (var l in lines) {
           var info = l.Split(',').Select(x=>x.Trim()).ToArray();
           var b = new BookInfo {
              title = info[0],
              author = info[1]+", " + info[2],
              i1 = int.Parse(info[3]),
              ...
           };
           allbooks.Add(b);
        }
    }
