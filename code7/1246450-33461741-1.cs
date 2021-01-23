    public partial class InputFieldControl : UserControl
    {
        // Required property
        public static readonly DependencyProperty RequiredProperty =
                       DependencyProperty.Register("Required", 
                       typeof(bool), typeof(InputFieldControl), 
                       new PropertyMetadata(true, OnRequiredChanged));
        private static void OnRequiredChanged(DependencyObject d, DependencyPropertyChangedEventArgs e){
            InputFieldControl ctrl = d as InputFieldControl;
            // symbol is voided
            if ((bool)e.NewValue == false)
                ctrl.RequiredStringSymbol = string.Empty;
        }
        public bool Required {
            get { return (bool)GetValue(RequiredProperty); }
            set { SetValue(RequiredProperty, value); }
        }
        // Required string symbol
        public static readonly DependencyProperty RequiredStringSymbolProperty =
                      DependencyProperty.Register("RequiredStringSymbol",
                      typeof(string), typeof(InputFieldControl),
                      new PropertyMetadata("*"));
        public string RequiredStringSymbol{
            get { return (string)GetValue(RequiredStringSymbolProperty); }
            set { SetValue(RequiredStringSymbolProperty, value); }
        }
        // Input Label
        public static readonly DependencyProperty InputLabelProperty =
                      DependencyProperty.Register("InputLabel",
                      typeof(string), typeof(InputFieldControl),
                      new PropertyMetadata(string.Empty));
        public string InputLabel{
            get { return (string)GetValue(InputLabelProperty); }
            set { SetValue(InputLabelProperty, value); }
        }
       
