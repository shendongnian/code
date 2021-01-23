       public void HandleClick(object sender, EventArgs e)
        {
            var clickedTableRow = sender as TableRow;
            int s = clickedTableRow.Id;
            // s is the index of the row, so just retrieve the matching object
            // from the data source
            var selected = tableItems[s];
        }
