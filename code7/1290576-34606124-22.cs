    public partial class Student_UC : UserControl
    {
        public Person_UC()
        {
            InitializeComponent();
            DataContext = new Student_UC_ViewModel();
        }
        ...
    }
