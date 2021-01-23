    public class Unit
    {
        public int UnitId { get; set; }
        public Engine EngineStuff { get; set; }
        public Unit()
        {
            EngineStuff = new EngineStuff();
        }
    }
