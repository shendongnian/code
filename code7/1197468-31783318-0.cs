    string colHeader = string.Empty;  // variable for the column header
    
    switch (index)
    {
    	case 0:
    		colHeader = "Preis/Stk. EURO";
    	case 1:
    		colHeader = "Stk.";
    	case 2:
    		colHeader = "Produkt";
    	default:
    		break;
    }
    
    // using the string variable here to set the actual column header
    oleDbCommand.Parameters.Add(new OleDbParameter(colHeader, _header));
