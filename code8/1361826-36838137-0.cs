    public class InterceptorPolicy : IInterceptorPolicy
    {
        private readonly IDictionary<string, string> typesToIntercept;
        public InterceptorPolicy(IDictionary<string, string> types)
        {
            this.typesToIntercept = types;
        }
        public IEnumerable<IInterceptor> DetermineInterceptors(Type pluginType, Instance instance)
        {
            if (instance.ReturnedType.IsSubclassOf(typeof(BaseType)))
            {
                yield return new ActivatorInterceptor<BaseType>((ctx, x) => this.Activate(ctx, x));
            }
        }
        private void Activate(IContext ctx, BaseType instance)
        {
            var key = instance.GetType().FullName;
            if (this.typesToIntercept.ContainsKey(key))
            {
                var propertyOverrideType = this.typesToIntercept[key];
                instance.BaseProperty = ctx.GetInstance<IBaseInterface>(propertyOverrideType);
            }
        }
    }
