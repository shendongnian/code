    namespace CoreServices.Services
    {
        public interface IServiceA
        {
            string Test { get; }
        } 
        
        public interface IServiceB
        {
            string Test { get; }
        }
    
        public class ServiceA : IServiceA
        {
            public virtual string Test 
            {
                get { return "CoreServices: ServiceA"; } 
            }
        }
    
        public class ServiceB : IServiceB
        {
            public virtual string Test
            {
                get { return "CoreServices: ServiceB"; }
            }
        }
    }
