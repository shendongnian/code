    public class Row {
        DateTime Time {get; set;}
        string CC { get; set; }
        string Month {get; set;}
        double PRC {get; set;}
        string Str {get; set;}
        double TX {get; set;}
        int QQ { get; set; }
    }
    var allEntries = new List<Row>();
    
    //Load data...
    
    var allEntriesDict = allEntries.Select(entry => entry.Time)
                                   .Distinct()
                                   .ToDictionary(time => time, 
                                                 time => allEntries.Where(entry => entry.Time == time).ToList());
    foreach(var kvp in allEntriesDictionary) {
        //kvp.Key is the Time
        //kvp.Value is a List<Row>
        DoCalculations(kvp.Value);
    }
