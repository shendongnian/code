    public static readonly DependencyProperty Custom_Text_Field_Color_Property =
            DependencyProperty.Register("Custom_Text_Field_Color", typeof(Brush), 
            typeof(Class_Name), new UIPropertyMetadata(null));
    
            public Brush Custom_Text_Field_Color
            {
                get { return (Brush)GetValue(Custom_Text_Field_Color_Property); }
                set { SetValue(Custom_Text_Field_Color_Property, value); }
            }
