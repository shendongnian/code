        private void dgvSearchResults_GetRowCellStyle(object sender, GridGetRowCellStyleEventArgs e)
        {
            if (e.StyleType != StyleType.Default) { return; }
            var row = e.GridRow as GridRow;
            if (row == null) { return; }
            if (((CustomerDTO)row.DataItem).Disabled) {
                e.Style.Background = new Background(Color.Tomato);
            }
        }
