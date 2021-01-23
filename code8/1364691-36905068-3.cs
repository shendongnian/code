    DataGrid dgvAssy = new DataGrid();
                
    dgv.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
    
    dgv.PreviewMouseWheel += DgvAssy_PreviewMouseWheel;
    
    private void DgvAssy_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
    {
         scrollviewer1.ScrollToVerticalOffset(scrollviewer1.VerticalOffset - e.Delta);
    }
