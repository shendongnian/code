    public class CharacterStats
    {
        public IEnumerable<BaseStat> GetStats() {
            yield return Level;
            yield return Health;
            yield return Damage;
            yield return Defense;
        }
    
        public BaseStat Level { get; set; }
        public BaseStat Health { get; set; }
        public BaseStat Damage { get; set; }
        public BaseStat Defense { get; set; }
    }
