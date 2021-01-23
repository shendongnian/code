    using System;
    using System.Data;
    using System.Windows;
    namespace WpfApplicationTest
    {
        public partial class MainWindow : Window
        {
            private DataTable myDataTable;
            private Random myRandom = new Random();
            public MainWindow()
            {
                InitializeComponent();
                myDataTable = new DataTable();
            
                // create some datatable
                myDataTable.Columns.Add("First");
                myDataTable.Columns.Add("Second");
                myDataTable.Rows.Add(myRandom.Next(100).ToString(), myRandom.Next(100).ToString());
                myDataTable.Rows.Add(myRandom.Next(100).ToString(), myRandom.Next(100).ToString());
                myDataGrid0.DataContext = myDataTable;
                myDataGrid1.DataContext = myDataTable;
            
                myDataTable.Columns.CollectionChanged += Columns_CollectionChanged;
            }
            private void Columns_CollectionChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
            {
                // refresh the grid views by reseting the data context after the columns have changed
                myDataGrid0.DataContext = null;
                myDataGrid0.DataContext = myDataTable;
                myDataGrid1.DataContext = null;
                myDataGrid1.DataContext = myDataTable;
            }
            private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
            {
                // refresh the grid views by reseting the data context
                myDataGrid0.DataContext = null;
                myDataGrid0.DataContext = myDataTable;
                myDataGrid1.DataContext = null;
                myDataGrid1.DataContext = myDataTable;
            }
            private void ButtonAddRow_Click(object sender, RoutedEventArgs e)
            {
                // add rows with random content
                DataRow row = myDataTable.NewRow();
                for (int i = 0; i < row.ItemArray.Length; ++i)
                    row[i] = myRandom.Next(100);
                myDataTable.Rows.Add(row);
            }
            int rowcount = 0;
            private void ButtonAddCol_Click(object sender, RoutedEventArgs e)
            {
                // add columns with random content
                myDataTable.Columns.Add("New" + rowcount.ToString());
                foreach (DataRow row in myDataTable.Rows)
                    row["New" + rowcount.ToString()] = myRandom.Next(100);
                ++rowcount;
            }
            private void ButtonEdit_Click(object sender, RoutedEventArgs e)
            {
                // randomly change some data table values
                myDataTable.Rows[myRandom.Next(myDataTable.Rows.Count)][myRandom.Next(myDataTable.Columns.Count)] = myRandom.Next(100);
            }
        }
    }
