    class ComplexTextPresenterElement
    {
        public static readonly DependencyProperty InputProperty = DependencyProperty.Register("Input", typeof(string), typeof(ComplexTextPresenterElement), new PropertyMetadata(default(string), InputPropertyChangedCallback));    
        public static readonly DependencyProperty InputCollectionProperty = DependencyProperty.Register("InputCollection", typeof(ObservableCollection<object>), typeof(ComplexTextPresenterElement), new PropertyMetadata(default(ObservableCollection<object>)));
        public static readonly DependencyProperty OnHyperlinkCommandProperty = DependencyProperty.Register("OnHyperlinkCommand", typeof(ICommand), typeof(ComplexTextPresenterElement), new PropertyMetadata(default(ICommand)));
    }
