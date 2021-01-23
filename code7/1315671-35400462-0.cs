    private class Example
    {
        public offSets curve1 { get; set; }
        public offSets curve2 { get; set; }
        public List<offSets> lstCurves { get; set; }
        public string testString { get; set; }
        public Example()
        {
            this.curve1 = new offSets();
            this.curve2 = new offSets();
            this.lstCurves = new List<offSets>();
        }
        public double[] somemethod()
        {
           //code that returns an array - something lie:
           return this.lstCurves.Select(i => i.d2).ToArray();
        }
    }
