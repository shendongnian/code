    public class XMLToColumn
    {
        public static bool GetGenerateColumnForGrid(DependencyObject obj)
        {
            return (bool)obj.GetValue(GenerateColumnForGridProperty);
        }
        public static void SetGenerateColumnForGrid(DependencyObject obj, bool value)
        {
            obj.SetValue(GenerateColumnForGridProperty, value);
        }
        // Using a DependencyProperty as the backing store for GenerateColumnForGrid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GenerateColumnForGridProperty =
            DependencyProperty.RegisterAttached("GenerateColumnForGrid", typeof(bool), typeof(XMLToColumn), new PropertyMetadata(GenerateColumnForGridChanged));
        public static void GenerateColumnForGridChanged(DependencyObject DO, DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = DO as DataGrid;
            if (dataGrid != null && Convert.ToBoolean(e.NewValue) == true)
            {
                dataGrid.Loaded += dataGrid_Loaded;
            }
        }
        static void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                dataGrid.Columns.Clear();
                var dataprovider = dataGrid.DataContext as XmlDataProvider;
                if (dataprovider != null)
                {
                    var mainNode = dataprovider.Document.SelectSingleNode(dataprovider.XPath);
                    foreach (var item in mainNode.ChildNodes)
                    {
                        var node=item as XmlNode;
                        var column = new DataGridTextColumn();
                        column.Binding = new Binding() { XPath = node.Name+"/." };
                        column.Header = node.Name;
                        dataGrid.Columns.Add(column);
                    }
                }
            }
        }
    }
