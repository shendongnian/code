    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    namespace ListViewTest
    {
        public class Column
        {
            public string Title { get; set; }
            public string SourceField { get; set; }
        }
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                GridView gridView = new GridView();
                this.myListView.View = gridView;
                List<dynamic> myItems = new List<dynamic>();
                dynamic myItem;
                IDictionary<string, object> myItemValues;
                // Populate the objects with dynamic columns
                for (var i = 0; i < 100; i++)
                {
                    myItem = new System.Dynamic.ExpandoObject();
                    foreach (string column in new string[] { "Id", "Name", "Something" })
                    {
                        myItemValues = (IDictionary<string, object>)myItem;
                        myItemValues[column] = "My value for " + column + " - " + i;
                    }
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
                    var binding = new Binding(column.SourceField);
                    gridView.Columns.Add(new GridViewColumn { Header = column.Title, DisplayMemberBinding = binding });
                }
            
                // Add all items to the list
                foreach (dynamic item in myItems)
                {
                    this.myListView.Items.Add(item);
                }
            }
        }
    }
