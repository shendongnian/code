    public partial class ListViewWithGrid : ContentPage
    {
        public ListViewWithGrid()
        {
            InitializeComponent();
            BindingContext = new ListViewWithGridViewModel();
        }
    }
