    public class SelectListViewItemWhenElementGotFocusBehavior : DependencyObject, IBehavior
    {
        private UIElement _element;
        public DependencyObject AssociatedObject { get; set; }
        #region ListView reference
        public ListView ListView
        {
            get { return (ListView)GetValue(ListViewProperty); }
            set { SetValue(ListViewProperty, value); }
        }
        public static readonly DependencyProperty ListViewProperty =
            DependencyProperty.Register("ListView", typeof(ListView), typeof(SelectListViewItemWhenElementGotFocusBehavior), new PropertyMetadata(null));
        #endregion
        public void Attach(DependencyObject associatedObject)
        {
           AssociatedObject = associatedObject;
            _element = this.AssociatedObject as UIElement;
            if (_element != null)
            {
                _element.GotFocus += OnElementGotFocus;
            }
        }
        private void OnElementGotFocus(object sender, RoutedEventArgs e)
        {
            var item = ((AutoSuggestBox)sender).DataContext;
            var container = (ListViewItem)ListView.ContainerFromItem(item);
            container.IsSelected = true;
        }
        public void Detach()
        {
            if (_element != null)
            {
                _element.GotFocus += OnElementGotFocus;
            }
        }
    }
