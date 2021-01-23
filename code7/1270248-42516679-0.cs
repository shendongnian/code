    public class BaseNavigationPage : NavigationPage
	{
        public BaseNavigationPage() : base()
		{
			this.BarTextColor = Color.White;
		}
		public BaseNavigationPage(Page page) : base(page)
		{
			this.BarTextColor = Color.White;
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(CurrentPage))
            {
                Current = CurrentPage;
            }
        }
        private void CurrentPage_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName == NavigationPage.HasNavigationBarProperty.PropertyName && _bounds == Rectangle.Zero)
            {
                _bounds = CurrentPage.Bounds;
            }
        }
        private void Current_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == NavigationPage.HasNavigationBarProperty.PropertyName)
            {
                var has = NavigationPage.GetHasNavigationBar(CurrentPage);
                if (has)
                {
                    CurrentPage.Layout(_bounds);
                    _bounds = Rectangle.Zero;
                }
                else
                {
                    CurrentPage.Layout(this.Bounds);
                }
            }
        }
        private Page Current
        {
            get { return _current; }
            set
            {
                if (_current != null)
                {
                    _current.PropertyChanging -= CurrentPage_PropertyChanging;
                    _current.PropertyChanged -= Current_PropertyChanged;
                }
                _current = value;
                if (_current != null)
                {
                    _current.PropertyChanging += CurrentPage_PropertyChanging;
                    _current.PropertyChanged += Current_PropertyChanged;
                }
            }
        }
        private Page _current;
        private Rectangle _bounds;
    }
