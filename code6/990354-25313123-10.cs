    public class RegionNavigationJournalWrapper : IRegionNavigationJournal
    {
        private readonly IRegionNavigationJournal _regionNavigationJournal;
        private readonly Stack<Uri> _backStack = new Stack<Uri>();
        // Constructor inject prism default RegionNavigationJournal to wrap
        public RegionNavigationJournalWrapper(RegionNavigationJournal regionNavigationJournal)
        {
            _regionNavigationJournal = regionNavigationJournal;
        }
        public string PreviousViewName
        {
            get
            {
                if (_backStack.Count > 0)
                {
                    return _backStack.Peek().OriginalString;
                }
                return String.Empty;
            }
        }
        public bool CanGoBack
        {
            get { return _regionNavigationJournal.CanGoBack; }
        }
        public bool CanGoForward
        {
            get { return _regionNavigationJournal.CanGoForward; }
        }
        public void Clear()
        {
            _backStack.Clear();
            _regionNavigationJournal.Clear();
        }
        public IRegionNavigationJournalEntry CurrentEntry
        {
            get { return _regionNavigationJournal.CurrentEntry; }
        }
        public void GoBack()
        {
            // Save current entry
            var currentEntry = CurrentEntry;
            // try and go back
            _regionNavigationJournal.GoBack();
            // if currententry isn't equal to previous entry then we moved back
            if (CurrentEntry != currentEntry)
            {
                _backStack.Pop();
            }
        }
        public void GoForward()
        {
            // Save current entry
            var currentEntry = CurrentEntry;
            // try and go forward
            _regionNavigationJournal.GoForward();
            // if currententry isn't equal to previous entry then we moved forward
            if (currentEntry != null && CurrentEntry != currentEntry)
            {
                _backStack.Push(currentEntry.Uri);
            }
        }
        public INavigateAsync NavigationTarget
        {
            get { return _regionNavigationJournal.NavigationTarget; }
            set { _regionNavigationJournal.NavigationTarget = value; }
        }
        public void RecordNavigation(IRegionNavigationJournalEntry entry)
        {
            var currentEntry = CurrentEntry;
            _regionNavigationJournal.RecordNavigation(entry);
            // if currententry isn't equal to previous entry then we moved forward
            if (currentEntry != null && CurrentEntry == entry)
            {
                _backStack.Push(currentEntry.Uri);
            }
        }
    }
