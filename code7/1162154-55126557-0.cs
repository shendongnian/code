    public partial class SetupForm : UserControl
    {
        public SetupForm()
        {
            InitializeComponent();
            DataContext = new SetupFormVM();
        }
    }
