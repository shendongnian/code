    private void POI_grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                decimal por_x;
                try
                {
                    por_x = Convert.ToDecimal(POI_grid.CurrentCell.Value);
                }
                catch
                {
    
                   POI_grid.CurrentCell.Value= "0";
                }
    
    
            }
    
            private void POI_grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
            {
                if (e.Exception is FormatException)
                {
                    MessageBox.Show("Debe ingresar números decimales solamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Verifique el formato del número ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
