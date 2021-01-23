    public partial class CustomComboBoxColumn : DataGridComboBoxColumn, ICommandSource
    {
        public CustomComboBoxColumn()
        {
            InitializeComponent();
        }
        private void SomeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseCommand();
        }
