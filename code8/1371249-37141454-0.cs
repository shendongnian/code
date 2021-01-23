    SqlDataAdapter da;
    DataTable dt;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = stackoverlowConnectionString;
            Conn.Open();
            
            SqlCommand gridcomm = new SqlCommand();
            gridcomm.Connection = Conn;
            gridcomm.CommandText = "SELECT Id, Name, Quantity, Rate, Time FROM Budget";
            da = new SqlDataAdapter(gridcomm);
            
            SqlDataReader gridreader = gridcomm.ExecuteReader();
            while (gridreader.Read())
            {
            }
            gridreader.Close();
            dt= new DataTable("Budget");
            da.Fill(dt);
            dataGrid_Budget.ItemsSource = dt.DefaultView;
            Conn.Close();
        }
        private void dataGrid_Budget_RowEditEnding(object sender, System.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            DataGridRow editedrow = e.Row;
            int row_index = (DataGrid)sender).ItemContainerGenerator.IndexFromContainer(editedrow);
            for (int k=0;k< 5;k++)
            {
                DataGridCell cell = GetCell(row_index, k);
                TextBlock tb = cell.Content as TextBlock;
                if (k==1)
                {
                    dt.Rows[row_index][k] = tb.Text;
                }
                else if (k == 4)
                {
                    if (tb.Text != "")
                    {
                        dt.Rows[row_index][k] = Convert.ToDateTime(tb.Text);
                    }
                }
                else
                {
                    dt.Rows[row_index][k] = Convert.ToInt32(tb.Text);
                }
            }
            
            da.UpdateCommand = new SqlCommandBuilder(da).GetUpdateCommand();
            
            da.Update(dt);
        }
        public DataGridCell GetCell(int row, int column)
        {
            DataGridRow rowContainer = GetRow(row);
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    dataGrid_Budget.ScrollIntoView(rowContainer, dataGrid_Budget.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }
        public DataGridRow GetRow(int index)
        {
            DataGridRow row = (DataGridRow)dataGrid_Budget.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                dataGrid_Budget.UpdateLayout();
                dataGrid_Budget.ScrollIntoView(dataGrid_Budget.Items[index]);
                row = (DataGridRow)dataGrid_Budget.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
