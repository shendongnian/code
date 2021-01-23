    string[] Values { get; set; } = new string[0]; // not needed
    IEnumerable<string> Values { get; set; } = new string[0]; //$type needed
    IEnumerable<string> Values { get; set; } = new Stack<string>(); //$type needed
    IEnumerable<string> Values { get; set; } = new List<string>; // not needed
    List<string> Values { get; set; } = new List<string>; // not needed
    
    ObservableCollection<string> Values { get; set; } = 
        new ObservableCollection<string>(); // not needed
   
