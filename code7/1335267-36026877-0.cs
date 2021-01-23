	var quantityInput = sender as TextBox;
	double quantity = 0;
	double price = 0;
	double.TryParse(txtPrice.Text, out price);
	
	if (quantityInput != null)
	{
		double.TryParse(quantityInput.Text.Trim(), out quantity);
	}
	
	txtSubtotal.Text = quantity * price;
