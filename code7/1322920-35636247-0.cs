    [MarkupExtensionReturnType(typeof(OneWayToSourceBinding))]
    public class OneWayToSourceBinding : Binding
    {
        public OneWayToSourceBinding()
        {
            Mode = BindingMode.OneWayToSource;
        }
    
        public OneWayToSourceBinding(string path) : base(path)
        {
            Mode = BindingMode.OneWayToSource;
        }
    
        public new BindingMode Mode
        {
            get { return BindingMode.OneWayToSource; }
            set
            {
                if (value == BindingMode.OneWayToSource)
                {
                    base.Mode = value;
                }
            }
        }
    }
