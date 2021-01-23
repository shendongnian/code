    public abstract class BaseView<T> : MvxWindowsPage<T> where T : MvxViewModel
    {
        private ICommand _goBackCommand;
        public ICommand GoBackCommand
        {
            get { return _goBackCommand ?? (_goBackCommand = new MvxCommand(GoBack, CanGoBack)); }
            set { _goBackCommand = value; }
        }
        protected BaseView()
        {
            NavigationCacheMode = NavigationCacheMode.Required;
            Loaded += (s, e) => {
                HardwareButtons.BackPressed += HardwareButtonsBackPressed;
            };
            Unloaded += (s, e) => {
                HardwareButtons.BackPressed -= HardwareButtonsBackPressed;
            };
        }
        private void HardwareButtonsBackPressed(object sender, BackPressedEventArgs e)
        {
            if (GoBackCommand.CanExecute(null))
            {
                e.Handled = true;
                GoBackCommand.Execute(null);
            }
        }
        public virtual void GoBack()
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }
        public virtual bool CanGoBack()
        {
            return Frame != null && Frame.CanGoBack;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
                ViewModel = null;
            base.OnNavigatedTo(e);
        }
    }
