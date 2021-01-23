     private void dgUpitnik_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgUpitnik.Rows[e.RowIndex].ErrorText = "";
            int newInteger;
            if (e.ColumnIndex == 2)
            {
                if (dgUpitnik.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger > 3)
                    {
                        e.Cancel = true;
                        dgUpitnik.Rows[e.RowIndex].ErrorText = "Ocjena mora biti u rasponu od 0 do 3!";
                    }
                }
            }
        }
