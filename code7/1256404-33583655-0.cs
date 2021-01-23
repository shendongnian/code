     var sb = new StringBuilder();
     foreach (DataGridViewRow row in dataGridView1.Rows)
     {    
         sb.Append('<');
         foreach (DataGridViewColumn col in dataGridView1.Columns)
         {
                sb.Append(dataGridView1.Rows[row.Index].Cells[col.Index].Value);
                sb.Append(' ');
         }
         sb.Append('>');
     }
     var toInvoiceField = sb.ToString();
