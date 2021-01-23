     public partial class MainWindow : Window
    {
        private ViewModel VM { get; set; }
        private DataGridCellInfo activeCellAtEdit { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            this.VM = new ViewModel();
            this.DataContext = this.VM;
        }
        private void MyDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            this.activeCellAtEdit = MyDataGrid.CurrentCell;
        }
        private void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
             //assumes columns are all TextBoxes
            TextBox t = e.EditingElement as TextBox; 
            string editedCellValue = t.Text.ToString();
            //assumes item property bound to datagrid is of type string
            string originalValue = activeCellAtEdit.Item.SomeStringProperty;
            //compare strings
            if(editedCellValue != originalValue)
            {
                //do something
            }
        }
    }
