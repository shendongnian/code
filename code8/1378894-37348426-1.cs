    public partial class MainWindow : Window
    {
       public MainWindow()
       {
          InitializeComponent();
          mylistview.ItemsSource = CreateTable().DefaultView;
        }
    public DataTable CreateTable()//create a datatable
    {
       DataTable dt = new DataTable();
       dt.Columns.Add("Name", typeof(string));
       dt.Columns.Add("Number", typeof(double));
         
       dt.Rows.Add("A", 1234.78);
       dt.Rows.Add("B", 12.0);
       dt.Rows.Add("C", 7.89);
          
       return dt;
    }
     
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        foreach (DataColumn DCol in CreateTable().Columns)
         {
            GridViewColumn gvc3 = new GridViewColumn();
            Binding bind = new Binding(DCol.ColumnName);
            if (DCol.DataType == typeof(System.Double)) //add the double value typed columns
             {
                 bind.StringFormat = "{0:0.000}";
                 DataTemplate cell = new DataTemplate(); // create a datatemplate
                 FrameworkElementFactory factory = new FrameworkElementFactory(typeof(TextBlock));
                 factory.SetBinding(TextBlock.TextProperty, bind);//the second parameter should be bind
                 factory.SetValue(TextBlock.WidthProperty, 50D);
                 factory.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Right);//set the text align to right
                 factory.SetValue(TextBlock.BackgroundProperty, System.Windows.Media.Brushes.Blue);
                 factory.SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(Colors.Yellow));
                 cell.VisualTree = factory;
                 gvc3.CellTemplate = cell;
                 gvc3.Header = DCol.ColumnName;
                 myGridView.Columns.Add(gvc3);
           }
           else       //add other columns
           {
                gvc3.DisplayMemberBinding = bind;
                gvc3.Header = DCol.ColumnName;
                myGridView.Columns.Add(gvc3);
            }
              
        }    
     }
    }//MainWindow       
