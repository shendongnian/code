    public class ArgumentMap : BaseMap<Argument, int>
    {
        public ArgumentMap()
        {
            Property(x => x.Value).IsRequired();
            HasRequired(x => x.Series);
            HasRequired(x => x.Type);
        }
    }
    
    public GradientArgumentMap: ArgumentMap
    {
         public GradientArgumentMap(){...}
    
    }
    
    public LambdaArgumentMap: ArgumentMap
    {
         public LambdaArgumentMap(){...}
    
    }
