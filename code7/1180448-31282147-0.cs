    public class DisposingLifetimeStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            ILifetimePolicy lifeTime = context.Policies.Get<ILifetimePolicy>(context.BuildKey);               
            base.PreBuildUp(context);
        }
        public override void PreTearDown(IBuilderContext context)
        {
            // Assumes registration name is null
            var buildKey = new NamedTypeBuildKey(context.Existing.GetType());
            ILifetimePolicy lifeTime = context.Policies.Get<ILifetimePolicy>(buildKey);
            base.PreTearDown(context);
        }
    }
