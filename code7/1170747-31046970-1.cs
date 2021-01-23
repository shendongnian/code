               decimal amount = 0;
               CultureInfo us = new CultureInfo("en-US");
               CultureInfo custom = (CultureInfo)us.Clone();
               custom.NumberFormat.CurrencySymbol = "GHS ";
               
              
               foreach (DataGridViewRow row in dataGridView1.Rows)
               {
                   for (int index = 0; index < dataGridView1.ColumnCount - 1; index++)
                   {
                       DataGridViewCell cell = row.Cells[index];
                       if (cell.Value == DBNull.Value || cell.Value == null)
                           continue;
                       if (cell.Value.ToString().Contains("Payment"))
                       {
                           DataGridViewCell next = row.Cells[index + 1];
                           string s4 = next.Value.ToString();
                           amount+= Decimal.Parse(s4, NumberStyles.Currency, custom);
                          
                                textBox22.Text = amount.ToString();
                           }
                          
                       }
                   }
