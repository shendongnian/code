    namespace X.A
    {
        public class AControllerTypeResolver : DefaultHttpControllerTypeResolver
        {
            public AControllerTypeResolver() : base(IsHttpEndpoint)
            {
            }
    
            private static bool IsHttpEndpoint(Type t)
            {    
                if (t == null) throw new ArgumentNullException("t");
                return t.IsClass &&
                    t.IsVisible &&
                    !t.IsAbstract &&
                    typeof(ABaseController).IsAssignableFrom(t);
            }
        }
    }
