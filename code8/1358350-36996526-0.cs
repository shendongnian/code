    public class BindingResourceExtension : StaticResourceExtension
    {
        public BindingResourceExtension() : base() { }
    
        public BindingResourceExtension(object resourceKey) : base(resourceKey) { }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = base.ProvideValue(serviceProvider) as BindingBase;
            if (binding != null)
                return binding.ProvideValue(serviceProvider);
            else
                return null; //or throw an exception
        }
    }
