    public class ComboBox : System.Windows.Controls.ComboBox
    {
        public static readonly DependencyProperty TextBoxTagProperty =
            DependencyProperty.Register("TextBoxTag", typeof(object), typeof(ComboBox), new UIPropertyMetadata(null, new PropertyChangedCallback(OnTextBoxTagChanged)));
    
        public object TextBoxTag
        {
            get { return (object)GetValue(TextBoxTagProperty); }
            set { SetValue(TextBoxTagProperty, value); }
        }
    
            
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
    
            FrameworkElement frameworkElement = GetTemplateChild("PART_EditableTextBox") as FrameworkElement;
            frameworkElement.Tag = TextBoxTag;
        }
    
        private static void OnTextBoxTagChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ComboBox comboBox = d as ComboBox;
            FrameworkElement frameworkElement = comboBox.GetTemplateChild("PART_EditableTextBox") as FrameworkElement;
            frameworkElement.Tag = args.NewValue;
        }
    }
