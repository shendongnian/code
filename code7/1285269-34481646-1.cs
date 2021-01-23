    public class Bootstrapper : BootstrapperBase
    {
        private static IValueConverter hexConverter = new HexConverter();
    
        public Bootstrapper()
        {
            Initialize();
        }
    
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            /* Show your starting view model */
            DisplayRootViewFor<MainViewModel>();
        }
    
        protected override void Configure()
        {
            ConventionManager.ApplyValueConverter = (binding, dependencyProperty, propertyInfo) =>
                {
                    if (dependencyProperty == UIElement.VisibilityProperty && typeof(bool).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        binding.Converter = ConventionManager.BooleanToVisibilityConverter;
                        return;
                    }
    
                    if (dependencyProperty == TextBox.TextProperty && typeof(byte).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        binding.Converter = hexConverter;
                        return;
                    }
                };
        }
    }
