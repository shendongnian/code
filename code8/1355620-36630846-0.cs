    class Village
    {
        public double CurrentWood { get; private set; }
        public int WoodLevel { get; private set; }
        public double WoodProduction { get { return WoodLevel * 1.3; } } // Change the formula to your own
    
        public void Update()
        {
            // Update all your resources in here
            CurrentWood += Production;
        }
    }
