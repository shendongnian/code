    using System.Text.RegularExpressions;
    //====================================
    if (Regex.Match(nameTextBox.Text, "\\d").Success) 
	{
		MessageBox.Show("(Name) must contain No numbers");
		return ;
	}
	if (!Regex.Match(cardNumberTextBox.Text, "^\\d{16}$").Success) 
	{
		MessageBox.Show("(Card Number) must be Limited to 16 digits and no letters");
		return ;
	}
	if (!Regex.Match(expiryDateTextBox.Text, "^\\d{2}/\\d{2}$").Success) 
	{
		MessageBox.Show("(Expiry Date) must be Numbers like this - 02/17 and no letters");
		return ;
	}
	if (!Regex.Match(securityCodeTextBox.Text, "^\\d{3}$").Success) 
	{
		MessageBox.Show("(Security Code) must be Limited to 3 numbers and no letters.");
		return ;
	}
