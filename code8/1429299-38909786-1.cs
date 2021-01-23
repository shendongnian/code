    public class BroadcastPreviewDto : ISearchProperties {
        // implement ISearchProperties here
        // more, implementation-specific properties, e.g.
        public string BroadcastType { get; set; }
    }
    
    var bp = new BroadcastPreviewDto() {
        // set implementation specific properties here
        BroadcastType = "example"
    };
    
    // this compiles and executes fine
    PrepSearchProperties(bp);
    
    // Same instance as before. No properties stripped.
    Console.WriteLine(bp.BroadcastType);  
