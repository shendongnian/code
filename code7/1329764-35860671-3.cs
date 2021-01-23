    public partial class EditPanelControl : UserControl
    {
        public EditPanelControl()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += EditPanelControl_Loaded;
        }
        private void EditPanelControl_Loaded(object sender, RoutedEventArgs e)
        {
            AddSuperTextControl();
        }
        private void AddSuperTextControl()
        {
            var stc = new SuperTextControl();
            stc.SplitEvent += Stc_SplitEvent;
            stc.DeleteEvent += Stc_DeleteEvent;
            stc.SuperTextBox.Text = MainWindow.NextId.ToString();
            MainPanel.Children.Add(stc);
        }
        private void Stc_DeleteEvent(object sender, EventArgs e)
        {
            // todo: don't allow delete if only 1 child
            var stc = (SuperTextControl)sender;
            MainPanel.Children.Remove(stc);
        }
        private void Stc_SplitEvent(object sender, EventArgs e)
        {
            var stc = (SuperTextControl)sender; // fyi
            AddSuperTextControl();
        }
    }
