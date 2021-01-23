        public interface IEngine { }
    
        public class MustangEngine : IEngine
        {
            
        }
    
        public class EngineFactory
        {
    
            public static IEngine GetEngine(EngineType engine)
            {
                switch (engine)
                { case EngineType.Mustang: return new MustangEngine(); }
            }
        }
