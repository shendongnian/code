    public class MainWindowViewModel 
    {
        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<ITab>();
        }
        public ObservableCollection<ITab> Tabs { get; private set; }
    }
    public interface ITab
    {
        string Header { get; }
    }
