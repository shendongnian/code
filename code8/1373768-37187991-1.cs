    public partial class CloseConfirmWindow : Window
    {
        public CloseConfirmWindow(CloseConfirmViewModel model)
        {
            DataContext = model;
            InitializeComponent();
            model.Owner = this;
        }
    }
