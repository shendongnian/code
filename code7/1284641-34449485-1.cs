    public class FreezableProxyClass : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new FreezableProxyClass();
        }
        public static readonly DependencyProperty ProxiedDataContextProperty = DependencyProperty.Register(
            "ProxiedDataContext", typeof (object), typeof (FreezableProxyClass), new PropertyMetadata(default(object)));
        public object ProxiedDataContext
        {
            get { return (object) GetValue(ProxiedDataContextProperty); }
            set { SetValue(ProxiedDataContextProperty, value); }
        }
    }
