    public sealed class Container : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider
                .GetService(typeof(IProvideValueTarget));
            var targetProperty = provideValueTarget.TargetProperty as PropertyInfo;
            if (targetProperty == null)
            {
                throw new InvalidProgramException();
            }
            return BootStrapper.Resolver.Resolve(targetProperty.PropertyType);
        }
    }
