    namespace ConsoleApplication5
    {
        #region
    
        using AutoMapper;
    
        #endregion
    
        internal class Program
        {
            #region Methods
    
            private static void Main(string[] args)
            {
                Mapper.Initialize(
                    cfg =>
                    {
                        cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                        cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                    });
                var dog = Mapper.DynamicMap<Pig, Dog>(
                    new Pig
                    {
                        bark = "Bark!"
                    });
            }
    
            #endregion
        }
    
        public class Dog
        {
            #region Public Properties
    
            public string Bark { get; set; }
    
            #endregion
        }
    
        public class Pig
        {
            #region Public Properties
    
            public string bark { get; set; }
    
            #endregion
        }
    }
