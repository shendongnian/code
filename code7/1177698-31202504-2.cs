    The final registration will look like this : 
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new AutoActivateModule());
            builder.RegisterType<Foo>()
                    .As<IFoo>()
                    .As(AutoActivateService.From<IBar>())
                    .InstancePerOwned<IBar>();
            builder.RegisterType<Bar>()
                    .As<IBar>();
    Code for `AutoActivateService` and `AutoActivate` will be the following : 
        public class AutoActivateModule : Module
        {
            protected override void AttachToComponentRegistration(
                IComponentRegistry componentRegistry,
                IComponentRegistration registration)
            {
                foreach (IServiceWithType typedService in registration.Services.OfType<IServiceWithType>())
                {
                    registration.Activated += (sender, e) =>
                    {
                        Service autoActivateService = AutoActivateService.From(typedService.ServiceType);
                        foreach (IComponentRegistration r in componentRegistry.RegistrationsFor(autoActivateService))
                        {
                            e.Context.ResolveComponent(r, new Parameter[0]);
                        }
                    };
                }
            }
        }
        public class AutoActivateService : Service, IEquatable<AutoActivateService>
        {
            public static AutoActivateService From<T>()
            {
                return new AutoActivateService(typeof(T));
            }
            public static AutoActivateService From(Type targetType)
            {
                return new AutoActivateService(targetType);
            }
            private AutoActivateService(Type targetType)
            {
                this._targetType = targetType;
            }
            private readonly Type _targetType;
            public override String Description
            {
                get { return this.ToString(); }
            }
            public Type TargetType
            {
                get
                {
                    return this._targetType;
                }
            }
            public Boolean Equals(AutoActivateService other)
            {
                return other != null
                       && this._targetType == other._targetType;
            }
            public override Boolean Equals(Object obj)
            {
                return this.Equals(obj as AutoActivateService);
            }
            public override Int32 GetHashCode()
            {
                return this._targetType.GetHashCode();
            }
            public override String ToString()
            {
                return String.Format("Autoactivate service for {0}", this._targetType);
            }
        }
