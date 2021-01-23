    public class PumpItem
    {
        private string pumpID;
        public string PumpId
        {
            get
            {
                 return pumpId;
            }
            set
            {
                pumpId = value;
            }
        }
    
        private double fuelPumped;
        public double FuelPumped
        {
            get
            {
                 return fuelPumped;
            }
            set
            {
                fuelPumped = value;
            }
        }
    
        private double fuelCost;
        public double FuelCost
        {
            get
            {
                 return fuelCost;
            }
            set
            {
                fuelCost= value;
            }
        }
    
        public fuelSelection selection;
        public fuelSelection Selection
        {
            get
            {
                 return selection;
            }
            set
            {
                selection = value;
            }
        }
    
        public pumpState state;
        public pumpState State
        {
            get
            {
                 return state;
            }
            set
            {
                state = value;
            }
        }
    
        public PumpItem(string _ID)
        {
            this.PumpID = _ID;
            this.FuelPumped = 0;
            this.FuelCost = 0;
            this.Selection = fuelSelection.None;
            this.State = pumpState.Available;
        }
    }
