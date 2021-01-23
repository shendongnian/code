    public sealed partial class ButtonWithSymbolAndText : UserControl
    {
        public ButtonWithSymbolAndText()
        {
            this.InitializeComponent();
        }
    
        public static readonly DependencyProperty SymbolSizeProperty = DependencyProperty.Register("SymbolSize", typeof(int), typeof(ButtonWithSymbolAndText), null);
    
        public static readonly DependencyProperty TextSizeProperty = DependencyProperty.Register("TextSize", typeof(int), typeof(ButtonWithSymbolAndText), null);
    
        public string SymbolSize
        {
            get { return (string)GetValue(SymbolSizeProperty); }
            set { SetValue(SymbolSizeProperty, value); }
        }
    
        public int TextSize
        {
            get { return (int)GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }
    
    }
