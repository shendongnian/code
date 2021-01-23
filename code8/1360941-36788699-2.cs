    public partial class Window1 : Window
    {
        private ObservableCollection<string> _pplList;
    
            public Window1(ObservableCollection<string> ppList)
            {
                _ppList=ppList;
                InitializeComponent();
            }
