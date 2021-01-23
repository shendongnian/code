        public Article SelectedArticle
        {
            get { return (Article)GetValue(SelectedArticleProperty); }
            set { SetValue(SelectedArticleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SelectedArticle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedArticleProperty =
            DependencyProperty.Register("SelectedArticle", typeof(Article), typeof(MainWindow), new PropertyMetadata(null));
