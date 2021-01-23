    public class Agency : IReplaceable
    {
        public int AgencyID { get; set; }
        // other properties
        private int ParentID { get; set; }
        public Agency Parent { get; set; }
        
        IReplaceable IReplaceable.Parent
        {
            get 
            {
                return this.Parent; // calls Agency Parent
            }
            set
            {
                this.Parent = (Agency)value; // calls Agency Parent
            }
        }
    }
