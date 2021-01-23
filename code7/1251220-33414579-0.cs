    public class EnemyPrototype
    {
        public string Name  { get; set; }
        public int Level { get; set; }
    }
    public class EnemyProvider
    {
        private Dictionary<string, EnemyPrototype> _prototypes = 
            new Dictionary<string, EnemyPrototype>();
        public void AddPrototype(string key, EnemyPrototype prototype)
        {
            _prototypes[key] = prototype;
        }
        public EnemyFighter GetEnemy(string key)
        {
            var prototype = _prototypes[key];
            
            var fighter = new EnemyFighter();
            fighter.Name = prototype.Name;
            fighter.SetLevel(prototype.Level);
            return fighter;
        }
        
