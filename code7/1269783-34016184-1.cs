    public partial class SettingsView : Window
    {
        public SettingsView()
        {
            InitializeComponent();
        }
    
        private void ActiveItem_OnContentChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var newUserControl = (UserControl)e.NewValue;
            MinWidth = newUserControl.MinWidth;
            MinHeight = newUserControl.MinHeight;
            Width = MinWidth;
            Height = MinHeight;
        }
    }
