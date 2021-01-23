    public partial class EditWindow : Window
    {    
        public EditWindow()
        {
          InitializeComponent();
        }
    
        public EditWindow(object selectedItem) : this()
        {
          var yourSelectedItem = selectedItem;
        }
    }
