     private void DGData_DataError(object sender, DataGridViewDataErrorEventArgs anError)
            {
                if ((anError.Exception) is ConstraintException)
                {
                    DataGridView grd1 = (DataGridView)sender;
                    grd1.Rows[anError.RowIndex].ErrorText = "an error";
                    grd1.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";
    
                    anError.ThrowException = false;
                }
            }
      }
