     public class MainViewModel
    {
        private ObservableCollection<TabViewModel> tabs = new ObservableCollection<TabViewModel>();
        public ObservableCollection<TabViewModel> Tabs
        {
            get { return this.tabs; }
        }
    }
