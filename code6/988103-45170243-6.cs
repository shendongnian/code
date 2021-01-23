    /// <summary>
    /// Extended Context with Added Query Hints
    /// </summary>
    public class SomeEntitiesExtended : SomeEntities, IQueryHintable
    {
        public bool HintWithRecompile { get; set; }
        public SomeEntitiesExtended(string connectionString, bool hintWithRecompile) : base(connectionString)
        {
            HintWithRecompile = hintWithRecompile;
        }
        public SomeEntitiesExtended(bool hintWithRecompile) : base()
        {
            HintWithRecompile = hintWithRecompile;
        }
        public SomeEntitiesExtended(string connectionString) : base(connectionString)
        {
        }
        public SomeEntitiesExtended() : base()
        {
        }
    }
