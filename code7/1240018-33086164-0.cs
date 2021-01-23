    public partial class ArticleButton : UserControl
    {
        public ArticleButton()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                "Title",
                typeof(String),
                typeof(ArticleButton),
                new PropertyMetadata("Test", TitlePropertyChanged));
        private static void TitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ArticleButton).TitlePropertyChanged(e);
        }
        private void TitlePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            //do something when property changed value
        }
        public String Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
