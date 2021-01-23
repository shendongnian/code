    public class ArgumentMap : BaseMap<Argument, int>
    {
        public ArgumentMap()
        {
            Property(x => x.Value).IsRequired();
            HasRequired(x => x.Series);
            HasRequired(x => x.Type);
             Map<Argument>(m => m.Requires("Type").HasValue("Course"))
                .Map<GradientArgument>(m => m.Requires("Type").HasValue("GradientArgument"))
                .Map<LambdaArgument>(m => m.Requires("Type").HasValue("LambdaArgument"));
        }
    }
    
    
