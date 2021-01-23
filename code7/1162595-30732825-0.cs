    public class TrimmedTextBox : TextBox
    {
        public bool Trim
        {
            get { return (bool)GetValue(TrimProperty); }
            set { SetValue(TrimProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Trim.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TrimProperty =
            DependencyProperty.Register("Trim", typeof(bool), typeof(TrimmedTextBox), new PropertyMetadata(true));
        public TextTrimming Trimming
        {
            get { return (TextTrimming)GetValue(TrimmingProperty); }
            set { SetValue(TrimmingProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Trimming.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TrimmingProperty =
            DependencyProperty.Register("Trimming", typeof(TextTrimming), typeof(TrimmedTextBox), new PropertyMetadata(TextTrimming.CharacterEllipsis));
        static TrimmedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TrimmedTextBox), new FrameworkPropertyMetadata(typeof(TrimmedTextBox)));
        }
    }
