     if(dst.Rows.Count>0&&productsDataGridView.CurrentCell!=null)
     {
       try
        {
            dst.Rows.RemoveAt(productsDataGridView.CurrentCell.RowIndex);
            productsDataGridView.DataSource = dst;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
     }
