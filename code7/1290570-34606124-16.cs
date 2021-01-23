    public partial class Person_UC : UserControl
    {
        public Person_UC()
        {
            InitializeComponent();
            DataContext = new Person_UC_ViewModel();
        }
        ...
    }
