    public class Birds
    {
        public string Test { get; set; }
        //Binding source must be a property!!
        public List<Bird> _Birds { get; set; } = new List<Bird>();
        public List<Bird> Bird
        {
            get
            {
                return this._Birds;
            }
        }
    }
