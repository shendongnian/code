    public class oBaseExtended : oBase
    {
        public string foo { get; set; }
        public string bar { get; set; }
        public oBaseExtended() { }
        public oBaseExtended(int i) : base(i)
        {
            // this will invoke base class contructor to populate base members
            // then populate extended members afterwards if applicable
        }
    }
