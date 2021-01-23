        public static bool IsDesignMode(this object o)
        {
            return (bool) DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof (FrameworkElement)).Metadata.DefaultValue;
        }
        if (!this.IsDesignMode())
        {
            Task.Factory.StartNew(GoBack, ... 
            ...
        }
    
