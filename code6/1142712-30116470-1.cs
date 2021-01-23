    // Confirm that the cell is an integer.
    if (!int.TryParse(e.FormattedValue.ToString(), out output))
    {                
    		e.Cancel = true;
    		MessageBox.Show("Quantity must be numeric");
    }
    else if (output <= 0)
    {            
    	e.Cancel = true;
    	MessageBox.Show("Quantity must not be negative");
    }
