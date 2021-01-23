        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)yourDataGridView.SelectedItem;
            int ID = Convert.ToInt32(dataRowView.Row[0]);
        }
