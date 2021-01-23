    public partial class AlarmsView : UserControl
    {
        public static AlarmsView View;
        public AlarmsView()
        {
            InitializeComponent();
            View = this;
            this.DataContext = new ViewModel.AlarmsViewModel();
            
        }
    }
