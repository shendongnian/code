    public class Column
    {
        public string Title { get; set; }
        public string SourceField { get; set; }
    }
    public partial class MainWindow : Window
    {
        private BitmapImage LoadImage()
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(@"D:\image.png", UriKind.Absolute);
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.EndInit();
            return img;
        }
        public MainWindow()
        {
            InitializeComponent();
            GridView gridView = new GridView();
            this.myListView.View = gridView;
            List<dynamic> myItems = new List<dynamic>();
            dynamic myItem;
            IDictionary<string, object> myItemValues;
            var image = LoadImage();
            // Populate the objects with dynamic columns
            for (var i = 0; i < 100; i++)
            {
                myItem = new System.Dynamic.ExpandoObject();
                foreach (string column in new string[] { "Id", "Name", "Something" })
                {
                    myItemValues = (IDictionary<string, object>)myItem;
                    myItemValues[column] = "My value for " + column + " - " + i;
                }
                myItem.Icon = image;
                myItems.Add(myItem);
            }
            // Assuming that all objects have same columns - using first item to determine the columns
            List<Column> columns = new List<Column>();
            myItemValues = (IDictionary<string, object>)myItems[0];
            // Key is the column, value is the value
            foreach (var pair in myItemValues)
            {
                Column column = new Column();
                column.Title = pair.Key;
                column.SourceField = pair.Key;
                columns.Add(column);
            }
            // Add the column definitions to the list view
            gridView.Columns.Clear();
            foreach (var column in columns)
            {
                
                if (column.SourceField == "Icon")
                {
                    gridView.Columns.Add(new GridViewColumn
                    {
                        Header = column.Title,
                        CellTemplate = FindResource("iconTemplate") as DataTemplate
                    });
                }
                else
                {
                    var binding = new Binding(column.SourceField);
                    gridView.Columns.Add(new GridViewColumn { Header = column.Title, DisplayMemberBinding = binding });
                }
                
            }
            // Add all items to the list
            foreach (dynamic item in myItems)
            {
                this.myListView.Items.Add(item);
            }
        }
    }
