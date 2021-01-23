    public partial class Shell : Window
    {
        [InjectionConstructor]
        public Shell(ShellViewModel context)
        {
            DataContext = context;
            InitializeComponent();
        }
    }
