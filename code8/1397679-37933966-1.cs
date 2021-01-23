    class Tile : ContentControl
    {
        private static readonly DependencyPropertyKey ToolbarContentKey =
             DependencyProperty.RegisterReadOnly("ToolbarContent", typeof(ObservableCollection<UIElement>), typeof(Tile), new PropertyMetadata());
        public static readonly DependencyProperty ToolbarContentProperty = ToolbarContentKey.DependencyProperty;
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Tile), new PropertyMetadata());
        public ObservableCollection<UIElement> ToolbarContent
        {
            get { return (ObservableCollection<UIElement>)GetValue(ToolbarContentProperty); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public Tile()
        {
            SetValue(ToolbarContentKey, new ObservableCollection<UIElement>());
        }
    }
