    public class MultSelectKeyDGV : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            KeyEventArgs keyEventArgs = null;
            DataGridViewSelectedCellCollection selectedCells = null;
            bool selectRow = false;
    
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        keyEventArgs = new KeyEventArgs(Keys.Down);
                        selectedCells = this.SelectedCells;
                        break;
                    case Keys.Up:
                        keyEventArgs = new KeyEventArgs(Keys.Up);
                        selectedCells = this.SelectedCells;
                        break;
                    case Keys.Right:
                        keyEventArgs = new KeyEventArgs(Keys.Right);
                        selectedCells = this.SelectedCells;
                        break;
                    case Keys.Left:
                        keyEventArgs = new KeyEventArgs(Keys.Left);
                        selectedCells = this.SelectedCells;
                        break;
                    case Keys.Space:
                        keyEventArgs = new KeyEventArgs(Keys.None);
                        selectRow = true;
                        break;
                    default:
                        keyEventArgs = e;
                        break;
                }
            }
            else
            {
                keyEventArgs = e;
            }
          
            bool result = base.ProcessDataGridViewKey(keyEventArgs);
    
            if (e.Control)
            {
                this.CurrentRow.Selected = selectRow;
                this.KeepSelected(selectedCells); 
            }
    
            return result;
        }
    
        private void KeepSelected(DataGridViewSelectedCellCollection selected)
        {
            if (selected != null && this.MultiSelect)
            {
                foreach (DataGridViewCell cell in selected)
                {
                    cell.Selected = true;
                }
            }
        }
    }
