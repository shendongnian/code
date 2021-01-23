    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        DataRowView drv = DgEmp.SelectedItem as DataRowView;
        if (drv != null)
        {
            drv.Row.Delete();
        }
    }
