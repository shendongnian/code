    public partial class SomeEntities : DbContext, IQueryHintable
    {
        public bool HintWithRecompile { get; set; }
        public SomeEntities (string connectionString, bool hintWithRecompile) : base(connectionString)
        {
            HintWithRecompile = hintWithRecompile;
        }
        public SomeEntities (bool hintWithRecompile) : base()
        {
            HintWithRecompile = hintWithRecompile;
        }
        public SomeEntities (string connectionString) : base(connectionString)
        {
        }
    }
