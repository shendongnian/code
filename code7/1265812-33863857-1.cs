    public partial class EditWindow : Window
    {    
        public EditWindow()
        {
          InitializeComponent();
        }
    
        public EditWindow(YourObjectType selectedItem) : this()
        {
          var yourSelectedItem = selectedItem;
        }
    }
