     private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                //To handle 'ConstraintException' default error dialog (for example, unique value)
                if ((e.Exception) is ConstraintException)
                {
                    // ErrorText glyphs show
                    view.Rows[e.RowIndex].ErrorText = "must be unique value";
                    view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "must be unique value";
                    //...or MessageBox show
                    MessageBox.Show(e.Exception.Message, "Error ConstraintException",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Suppress a ConstraintException
                    e.ThrowException = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR: dataGridView1_DataError",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
