    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            DBDataContext dbContext = new DBDataContext();
            SP_Get_OrderItemResult orderRow = gridOrder.SelectedItem as SP_Get_OrderItemResult;                
            DataGrid grid = LogicalTreeHelper.FindLogicalNode(gridOrder, "gridOrderDetails") as DataGrid;                      
            grid.ItemsSource = dbContext.SP_Get_ItemList(orderRow.orderid); 
        }
        catch (Exception Ex)
        {
            MessageBox.Show(Ex.Message);
            return;
        }
    }
