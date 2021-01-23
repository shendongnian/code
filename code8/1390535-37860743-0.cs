    namespace X.A
    {
        public class AControllerTypeResolver : DefaultHttpControllerTypeResolver
        {
            public AControllerTypeResolver() : base(IsHttpEndpoint)
            {
            }
    
            private static bool IsHttpEndpoint(Type t)
            {    
                return typeof(ABaseController).IsAssignableFrom(t);
            }
        }
    }
