            private void ButtonClick(object sender, RoutedEventArgs e)
        {
            //Get column Index of selected cell & set as variable
            int colIndex = BoundPivotGrid.CurrentCell.Column.DisplayIndex;
           DataRowView drv = (DataRowView)BoundPivotGrid.SelectedItem;
            String valueOfItem = drv[colIndex].ToString();
            if (valueOfItem == "-")
            {
                MessageBox.Show("No file");
            }
            else
            {
                Process.Start(valueOfItem);
            }
