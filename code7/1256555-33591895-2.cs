    public class MainViewModel:BaseObservableObject
    {
        private string _contentFromDataContext;
        private Action<object> _onResizeAction;
        public MainViewModel()
        {
            OnResizeAction = new Action<object>(InnerOnResizeAction);
        }
        private void InnerOnResizeAction(object obj)
        {
            var args = obj as SizeChangedEventArgs;
            //do you logic here
        }
        public string ContentFromDataContext
        {
            get { return _contentFromDataContext; }
            set
            {
                _contentFromDataContext = value;
                OnPropertyChanged();
            }
        }
        public Action<object> OnResizeAction
        {
            get { return _onResizeAction; }
            set
            {
                _onResizeAction = value;
                OnPropertyChanged();
            }
        }
    }
