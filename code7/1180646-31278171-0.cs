    if (cell.Value.ToString().ToLower().Contains("string"))
    {
       if (cell.Value.ToString().ToLower().Contains("anotherstring"))
       {
    	   DataGridViewCell next = row.Cells[index + 1];
    	   string s4 = next.Value.ToString();
    	   amount += Decimal.Parse(s4, NumberStyles.Currency, custom);
    
    	   textBox50.Text = amount.ToString();
    
       }
    
    
       DataGridViewCell nexter = row.Cells[index + 1];
       string s5 = nexter.Value.ToString();
       sum += Decimal.Parse(s5, NumberStyles.Currency, custom);
    
       textBox41.Text = sum.ToString();
    
    }
