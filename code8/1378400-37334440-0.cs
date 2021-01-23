        private void gridViewDataViewer_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            if(formLoaded)
            {
                e.Handled = true;
                e.Visible = true;  
            }  
        }
       
        private void searchButton_Click(object sender, EventArgs e)
        {
            int rowHandle = gridViewDataViewer.LocateByValue("Column Name", gridViewDataViewer.FindFilterText);
            gridViewDataViewer.FocusedRowHandle = gridViewDataViewer.GetVisibleRowHandle(rowHandle);
            
        }
    
