    public class Issue
    {                          
        public string key { get; set; }
    }
   
    public class search
    {
        public IList<Issue> issues { get; set; }
    }
        
    private static void Main(string[] args) {
        search s = new search();
        s.issues.Add(new Issue()); // YOU HAVE THREE ISSUES
        s.issues.Add(new Issue());
        s.issues.Add(new Issue());
        var x=s.issues[0].key; // YOU ACCESS 1st one
        x = s.issues[2].key; // YOU ACCESS 3rd one (zero based)
           
             
    }
