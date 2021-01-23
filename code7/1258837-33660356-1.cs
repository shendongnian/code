    public partial class VerticalTextBlock : UserControl
    {
        public VerticalTextBlock()
        {
            InitializeComponent();
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
                typeof(string),
                typeof(VerticalTextBlock),
                new PropertyMetadata(string.Empty, textChangeHandler));
        private static void textChangeHandler(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var prop = d as VerticalTextBlock;
            var textBlock = prop.TheTextBlock;
            var str = (e.NewValue as string);
            textBlock.Inlines.Clear();
            for (int i = 0; i < str.Length-1; i++)
            {
                textBlock.Inlines.Add(new Run() { Text = str[i] + Environment.NewLine });
            }
            textBlock.Inlines.Add(new Run() { Text = str[str.Length-1].ToString()});
        }
    }
