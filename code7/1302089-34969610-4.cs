    public class Unit
    {
        public int UnitId { get; set; }
    
        private Engine engineStuff;
        public Engine EngineStuff
        {
            get
            {
                if (engineStuff == null) engineStuff = new EngineStuff();
                return engineStuff;
            }
        }
    }&#xD;
