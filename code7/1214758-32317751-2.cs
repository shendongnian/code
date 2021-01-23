    public static  DependencyProperty activeImage =
               DependencyProperty.Register("ActiveImage", typeof(type of this property like  "string"), typeof(type of the custom control that you need like  "MyButton"), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    
            public string ActiveImage
            {
                get { return (string)GetValue(activeImage); }
                set { SetValue(activeImage, value); }
            }
