    PumpItem pumpItem = pumpList.FirstOrDefualt(x => x.ID == ID)
    if (pumpItem == null)
        pumpList.Add(new PumpItem(ID));  
    else
        pumpItem.state = PoSClientWPF.pumpState.Available;
    class PumpItem
    {
        public double fuelPumped = 0;
        public double fuelCost = 0;
        public fuelSelection selection = fuelSelection.None;
        public pumpState state = pumpState.Available;
        public Int32? ID = null; 
    
        public PumpItem()//intialize constructor
        { }
        public PumpItem(Int32? ID)
        {
            this.ID = ID;
        }
    }
