    public partial class AddMember : Window
    {
        StructureGeneratorVM mainVM = null;
        public AddMember(object vm)
        {
            mainVM = (StructureGeneratorVM)vm;
            DataContext = mainVM;
            InitializeComponent();
        }
    }
