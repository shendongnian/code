    bool InteceptBarcode = false;
    string barcodeValue = string.empty;
    private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
    	if(InteceptBarcode)
    	{
    		barcodeValue = += e.Text
    		e.Handled = true; //The keyboard character will stop bubbling up the control tree 
    	}
    	else if (e.Text == char(2))  //Start of text character
    	{
    	  	InterceptBarcode = true;
    	  	barcodeValue = string.empty;
    		e.Handled = true;
    	}
    	else if (e.Text == char(3)) //End of text character
    	{
    	    	InterceptBarcode = false
    		e.Handled = true;
    		//Now do what ever you need to do on the UI.
    	}
    	else
    	{
    		e.Handled = false;
    	}					
    }
