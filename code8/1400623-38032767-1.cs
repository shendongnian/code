    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rowGroup = tblDummyData.RowGroups.FirstOrDefault();
    
            if (rowGroup != null)
            {
                TableRow row = new TableRow();
    
                TableCell cell = new TableCell();
    
                cell.Blocks.Add(new Paragraph(new Run("New Cell 1")));
                row.Cells.Add(cell);
    
                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run("New cell 2")));
                row.Cells.Add(cell);
    
                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run("New cell 3")));
                row.Cells.Add(cell);
    
                rowGroup.Rows.Add(row);
            }
        }
