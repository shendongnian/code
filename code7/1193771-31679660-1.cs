    public partial class PersonRectangle : UserControl
    {
        public PersonRectangle()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
        }
    }
