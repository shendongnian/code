    public class RefreshActionButtonWrapper
    {
        private readonly IMenu _optionsMenu;
        public RefreshActionButtonWrapper(IMenu optionsMenu)
        {
            _optionsMenu = optionsMenu;
        }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                var dispatcher = MvxMainThreadDispatcher.Instance;
                dispatcher.RequestMainThreadAction(() => SetRefreshActionButtonState(_isBusy));
            }
        }
        public void SetRefreshActionButtonState(bool refreshing)
        {
            if (_optionsMenu == null) return;
            var refreshItem = _optionsMenu.FindItem(Resource.Id.refresh_action);
            if (refreshing)
            {
                refreshItem.SetActionView(Resource.Layout.actionbar_indeterminate_progress);
            }
            else
            {
                refreshItem.SetActionView(null);
            }
        }
    }
