        private void MyDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();
            int columnIndex = e.Column.DisplayIndex;
    
            // change some property of e.Column based on headerName or columnIndex
        }
