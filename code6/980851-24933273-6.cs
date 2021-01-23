    /// <summary>
    /// Returns the page ViewModel that the user is currently viewing.
    /// </summary>
    public ViewModelBase CurrentPage
    {
        get { return _currentPage; }
        private set
        {
            if (value != _currentPage)
            {
                if (_currentPage != null)
                    _currentPage.IsCurrentPage = false;
                _currentPage = value;
                if (_currentPage != null)
                    _currentPage.IsCurrentPage = true;
                RaisePropertyChanged(() => CurrentPage);
            }
        }
    }
