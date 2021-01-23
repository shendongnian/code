    public class AutoFakeExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Strategies.AddNew<AutoFakeBuilderStrategy>(UnityBuildStage.PreCreation);
        }
        
        private class AutoFakeBuilderStrategy : BuilderStrategy
        {
            private static readonly MethodInfo _fakeGenericDefinition;
        
            static AutoFakeBuilderStrategy()
            {
                _fakeGenericDefinition = typeof(A).GetMethod("Fake", Type.EmptyTypes);
            }
            
            public override void PreBuildUp(IBuilderContext context)
            {
                if (context.Existing == null)
                {
                    var type = context.BuildKey.Type;
                    if (type.IsInterface || type.IsAbstract)
                    {
                        var fakeMethod = _fakeGenericDefinition.MakeGenericMethod(type);
                        var fake = fakeMethod.Invoke(null, new object[0]);
                        context.PersistentPolicies.Set<ILifetimePolicy>(new ContainerControlledLifetimeManager(), context.BuildKey);
                        context.Existing = fake;
                        context.BuildComplete = true;
                    }
                }
                base.PreBuildUp(context);
            }
        }
    }
