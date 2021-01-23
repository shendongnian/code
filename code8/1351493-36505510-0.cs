    public class CombinationDefinition
    {
        public string Name;
        public getString GetString;
        public Combination[] Combinations;
    }
    
    public static class CurrentEnvironment
    {
        public static CombinationDefinition[] Combinations = new CombinationDefinition[0];
        public static Environment Instance { get { return _instance.Value; } }
    
        static ThreadLocal<Environment> _instance = new ThreadLocal<Environment>(() =>
            {
                Environment environment = new Environment();
    
                foreach (var combination in Combinations)
                    environment.AddType(combination.Name, combination.GetString, combination.Combinations);
    
                return environment;
            });
    
        public static Value CreateValue(int t, byte[] bin)
        {
            return new Value(t, bin, Instance);
        }
    }
