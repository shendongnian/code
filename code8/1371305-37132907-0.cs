        /// <summary>
        /// The constructor.
        /// </summary>
        static CustomRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRadioButton),
           new FrameworkPropertyMetadata(typeof(CustomRadioButton)));
    
            [...]
    
            // Override the default value of the base-DependencyProperty GroupName, so the RadioButtons are synchronized as usual.
            // For usage of multiple groups the property GroupName has be set explicitly - as usual.
            GroupNameProperty.OverrideMetadata(typeof(CustomRadioButton),
           new FrameworkPropertyMetadata("group0"));
        }
