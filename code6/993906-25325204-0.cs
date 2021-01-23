    public void OnTextChange(object sender, EventArgs e)
		{           
			if((isEmpty(inputType)) || (isEmpty(inputAmount)) || (isEmpty(inputSupplier)))
				doneButton.Enabled = false;
			else
				doneButton.Enabled = true;
		} 
