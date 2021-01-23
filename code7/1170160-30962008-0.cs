    public partial class YourUserControl: UserControl
    {
        private PatientMgr PatientsViewModel;
        public YourUserControl()
        {
            InitializeComponent();
            PatientsViewModel = new PatientMgr();
            DataContext = PatientsViewModel;
        }
        public void AddComboItem(Patient item)
        {
            PatientsViewModel.ComboBoxItemsCollection.Add(item);
        }
        public void UpdateComboItem(Patient item)
        {
            //your update code
        }
