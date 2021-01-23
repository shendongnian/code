    public class SearchBoxTextErrorVisualStateAction : DependencyObject, IAction
    {
        public static readonly DependencyProperty ErrorVisualStateProperty = DependencyProperty.Register(
            "ErrorVisualState",
            typeof(string),
            typeof(SearchBoxTextErrorVisualStateAction),
            new PropertyMetadata(string.Empty));
        public string ErrorVisualState
        {
            get
            {
                return (string)this.GetValue(ErrorVisualStateProperty);
            }
            set
            {
                this.SetValue(ErrorVisualStateProperty, value);
            }
        }
        public static readonly DependencyProperty ValidVisualStateProperty =
            DependencyProperty.Register(
                "ValidVisualState",
                typeof(string),
                typeof(SearchBoxTextErrorVisualStateAction),
                new PropertyMetadata(string.Empty));
        public string ValidVisualState
        {
            get
            {
                return (string)this.GetValue(ValidVisualStateProperty);
            }
            set
            {
                this.SetValue(ValidVisualStateProperty, value);
            }
        }
        public object Execute(object sender, object parameter)
        {
            var searchBox = sender as SearchBox;
            if (searchBox != null)
            {
                VisualStateManager.GoToState(
                    searchBox,
                    string.IsNullOrWhiteSpace(searchBox.QueryText) ? this.ErrorVisualState : this.ValidVisualState,
                    true);
            }
            return parameter;
        }
    }
