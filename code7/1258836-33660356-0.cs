    public partial class VerticalTextBlock : TextBlock
    {
        public VerticalTextBlock()
        {
            InitializeComponent();
        }
        
        new public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        
        new public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
                typeof(string),
                typeof(VerticalTextBlock),
                new PropertyMetadata(string.Empty, textChangeHandler));
        private static void textChangeHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var prop = d as VerticalTextBlock;
            var str = (e.NewValue as string);
            var inlines = str.Select(x => new Run(x + Environment.NewLine));
            prop.Inlines.Clear();
            prop.Inlines.AddRange(inlines);
        }
    }
