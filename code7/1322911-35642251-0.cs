    public class ToggleExtension : UnityContainerExtension
    {
        private Toggle toggle;
        public ToggleExtension(Toggle toggle)
        {
            this.toggle = toggle;
        }
        protected override void Initialize()
        {
            Context.Strategies.Add(new ToggleBuildUpStrategy(this.toggle),
                UnityBuildStage.TypeMapping);
        }
    }
    public class ToggleBuildUpStrategy : BuilderStrategy
    {
        private Toggle toggle;
        public ToggleBuildUpStrategy(Toggle toggle)
        {
            this.toggle = toggle;
        }
        public override void PreBuildUp(IBuilderContext context)
        {
            // If we have an Interface<> then do some type mapping to the applicable concrete class
            // Note that I'm using Toggle here because something similar was used in the question
            if (context.BuildKey.Type.IsGenericType && 
                context.BuildKey.Type.GetGenericTypeDefinition() == typeof(Interface<>))
            {
                Type target = null;
                // Luckily HttpContext.Current.Request request context is available here
                // For other non-static contexts might have to work out how to inject into the extension
                if (this.toggle.IsOn(HttpContext.Current.Request))
                {
                    target = typeof(Class1<>);
                }
                else
                {
                    target = typeof(Class2<>);
                }
                // Get generic args
                Type[] argTypes = context.BuildKey.Type.GetGenericArguments();
                // Replace build key type Interface<> => Class1<> or Class2<>
                // So that the correct type is resolved
                context.BuildKey = new NamedTypeBuildKey(target.MakeGenericType(argTypes), 
                    context.BuildKey.Name);
            }
        }
    }
