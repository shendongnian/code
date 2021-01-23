    public static class RegistrationExtensions
    {
        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> OnlyForInheritorsOf<TLimit, TReflectionActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration, Type baseType)
                where TReflectionActivatorData : ReflectionActivatorData
        {
            registration.RegistrationData.Metadata.Add(RestrictingRegistrationModule.MetadataKey, baseType);
            return registration;
        }
    }
    public class RestrictingRegistrationModule : Autofac.Module
    {
        internal const String MetadataKey = "RestrictedType";
        internal class RestrictedAutowiringParameter : Parameter
        {
            public RestrictedAutowiringParameter(RestrictingRegistrationModule restrictingRegistrationModule)
            {
                this._restrictingRegistrationModule = restrictingRegistrationModule;
            }
            private readonly RestrictingRegistrationModule _restrictingRegistrationModule;
            public override Boolean CanSupplyValue(ParameterInfo pi, IComponentContext context, out Func<Object> valueProvider)
            {
                if (pi == null)
                {
                    throw new ArgumentNullException("pi");
                }
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                IInstanceLookup lookup = context as IInstanceLookup;
                if (lookup != null)
                {
                    IComponentRegistration registration;
                    if (context.ComponentRegistry.TryGetRegistration(new TypedService(pi.ParameterType), out registration))
                    {
                        Type restrictedType;
                        if (this._restrictingRegistrationModule.RestrictedRegistrations.TryGetValue(registration, out restrictedType))
                        {
                            Type callerType = lookup.ComponentRegistration.Activator.LimitType;
                            if (!(callerType == restrictedType || callerType.IsSubclassOf(restrictedType)))
                            {
                                throw new Exception(String.Format("Registration {0} is not compatible for type {1}", registration, callerType));
                            }
                        }
                        valueProvider = (() => context.ResolveComponent(registration, Enumerable.Empty<Parameter>()));
                        return true;
                    }
                }
                valueProvider = null;
                return false;
            }
        }
        public RestrictingRegistrationModule()
        {
            this._restrictedRegistrations = new Dictionary<IComponentRegistration, Type>();
        }
        private readonly Dictionary<IComponentRegistration, Type> _restrictedRegistrations;
        public Dictionary<IComponentRegistration, Type> RestrictedRegistrations
        {
            get
            {
                return this._restrictedRegistrations;
            }
        }
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            base.AttachToComponentRegistration(componentRegistry, registration);
            Object value;
            if (registration.Metadata.TryGetValue(RestrictingRegistrationModule.MetadataKey, out value))
            {
                this._restrictedRegistrations.Add(registration, (Type)value);
            }
            registration.Preparing += (sender, e) =>
            {
                e.Parameters = e.Parameters.Concat(new Parameter[] { new RestrictedAutowiringParameter(this) });
            };
        }
    }
