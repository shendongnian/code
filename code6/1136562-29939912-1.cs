    public class CustomConfigurationRegistrar : ConfigurationRegistrar
    {
        internal class LazyParameter : Parameter
        {
            public LazyParameter(Parameter originalParameter)
            {
                this._originalParameter = originalParameter;
            }
            private readonly Parameter _originalParameter;
            public override Boolean CanSupplyValue(ParameterInfo pi, IComponentContext context, out Func<Object> valueProvider)
            {
                Boolean canSupplyValue = this._originalParameter.CanSupplyValue(pi, context, out valueProvider);
                if (canSupplyValue)
                {
                    Func<Object> originalValueProvider = valueProvider;
                    valueProvider = () =>
                    {
                        try
                        {
                            return originalValueProvider();
                        }
                        catch
                        {
                            Console.WriteLine(pi.Member.Name);
                            // log it and throw or return default value
                            return null;
                        }
                    };
                }
                return canSupplyValue;
            }
        }
        protected override void RegisterConfiguredModules(ContainerBuilder builder, SectionHandler configurationSection)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            if (configurationSection == null)
            {
                throw new ArgumentNullException("configurationSection");
            }
            foreach (ModuleElement moduleElement in configurationSection.Modules)
            {
                this.RegisterConfiguredModule(builder, configurationSection, moduleElement);
            }
        }
        private void RegisterConfiguredModule(ContainerBuilder builder, SectionHandler configurationSection, ModuleElement moduleElement)
        {
            try
            {
                var moduleType = this.LoadType(moduleElement.Type, configurationSection.DefaultAssembly);
                IModule module = null;
                IEnumerable<Parameter> parameters = moduleElement.Parameters.ToParameters().Select(p => new LazyParameter(p));
                IEnumerable<Parameter> properties = moduleElement.Properties.ToParameters().Select(p => new LazyParameter(p));
                using (var moduleActivator = new ReflectionActivator(
                    moduleType,
                    new DefaultConstructorFinder(),
                    new MostParametersConstructorSelector(),
                    parameters,
                    properties))
                {
                    module = (IModule)moduleActivator.ActivateInstance(new ContainerBuilder().Build(), Enumerable.Empty<Parameter>());
                }
                builder.RegisterModule(module);
            }
            catch (Exception)
            {
                // log it
                throw;
            }
        }
    }
