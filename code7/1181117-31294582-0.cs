    public class HelpView
    {
        List<Uri> HistoryStack;
        int HistoryStack_Index;
        bool fromHistory;
        //Constructor
        public HelpView()
        {
            InitializeComponent();
            HistoryStack = new List<Uri>();
            HistoryStack_Index = 0;
            fromHistory = false;
            webBrowser1.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(webBrowser1_Navigated);
            updateNavButtons();
        }
    }
