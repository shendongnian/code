    public class Root : IRoot
    {
        public Secondary secondary { get; set; }
        public Tertiary tertiary { get; set; }
        public string foo { get; set; } // This wouldn't need to be cross-compatible
    	
    	ISecondary IRoot.secondary {get {return this.secondary;} set{;}}
    	ITertiary IRoot.tertiary {get {return this.tertiary;} set{;}}
    }
