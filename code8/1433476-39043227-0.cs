        private void gridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(gridView.SelectedCells.Count > 0)
            {
                var cell = gridView.SelectedCells[0];
                if (cell.Value != null)
                    MessageBox.Show(cell.Value.ToString());
            }
        }
