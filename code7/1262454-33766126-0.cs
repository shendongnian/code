    public class MainViewModel
    {
        ObservableCollection<ITabViewModel> Tabs { get; set; }
        int CurrentTabIndex { get; set; }
        int MaxTabIndex { get; set; }
        int Progress { get; set; }
        ICommand NextTab { get; set; }
        public MainViewModel()
        {
            Tabs = new ObservableCollection<ITabViewModel>();
            Tabs.Add(new Introduction());
            Tabs.Add(new Step1());
            Tabs.Add(new Step2());
            Tabs.Add(new Step3());
            Progress = 0;
            CurrentTabIndex = 0;
            MaxTabIndex = 0;
        }
    }
