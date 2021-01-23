    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace GridScrollViewer
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                CreateDataGrid();
            }
    
            public void CreateDataGrid()
            {
                DataTable dt = new DataTable();
    
                dt.Columns.Add("Col 1", typeof(string));
                dt.Columns.Add("Col 2", typeof(string));
                dt.Columns.Add("Col 3", typeof(string));
                dt.Columns.Add("Col 4", typeof(string));
                dt.Columns.Add("Col 5", typeof(int));
                dt.Columns.Add("Col 6", typeof(int));
                dt.Columns.Add("Col 7", typeof(int));
                dt.Columns.Add("Col 8", typeof(int));
                dt.Columns.Add("Col 9", typeof(int));
                dt.Columns.Add("Col 10", typeof(int));
                dt.Columns.Add("Col 11", typeof(int));
                dt.Columns.Add("Col 12", typeof(int));
                dt.Columns.Add("Col 13", typeof(int));
                dt.Columns.Add("Col 14", typeof(int));
    
                for (int i = 0; i < 10; i++)
                {
                    dt.Rows.Add("First field",
                        "Second field",
                        "Third field",
                        "Fourth field",
                        100*i+i,
                        100 * i + i+1,
                        100 * i + i+2,
                        100 * i + i+3,
                        100 * i + i+4,
                        100 * i + i+5,
                        100 * i + i+6,
                        100 * i + i+7,
                        100 * i + i+8,
                        100 * i + i+9);
                }
    
                myGrid.DataContext = dt;
            }
    
            public void UpdatemyColumnsText()
            {
                double size = 0;
                if (myGrid.Columns.Count > 4)
                {
                    size = myGrid.Columns[0].ActualWidth
                    + myGrid.Columns[1].ActualWidth
                    + myGrid.Columns[2].ActualWidth
                    + myGrid.Columns[3].ActualWidth;
                }
                myColumnsText.Text = ((int)size).ToString();
            }
    
            public void UpdateScrollViewerText()
            {
                ScrollViewer sc = (ScrollViewer)VisualTreeHelper.GetChild(
                    (VisualTreeHelper.GetChild(myGrid, 0)), 0);
                myScrollViewerText.Text = "actual width: " + (int)sc.ActualWidth
                    +" - desired size: " + (int)sc.DesiredSize.Width
                    +" - render size: " + (int)sc.RenderSize.Width
                    +" - viewport: " + (int)sc.ViewportWidth;
    
                myScrollViewerOffsetText.Text = ((int)sc.HorizontalOffset).ToString();
            }
    
            public void UpdateExpectedWidth()
            {
                double expectedWidth = 0;
                if (myGrid.Columns.Count > 4)
                {
                    expectedWidth = myGrid.ActualWidth -(myGrid.Columns[0].ActualWidth
                    + myGrid.Columns[1].ActualWidth
                    + myGrid.Columns[2].ActualWidth
                    + myGrid.Columns[3].ActualWidth);
                }
                myExpectedValueText.Text = ((int)expectedWidth).ToString();
            }
    
            private void myGrid_LayoutUpdated(object sender, EventArgs e)
            {
                UpdatemyColumnsText();
                UpdateScrollViewerText();
                UpdateExpectedWidth();
            }
    
        }
    }
