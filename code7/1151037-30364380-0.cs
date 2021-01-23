        if (txtFirst.Text.Length < 1 || txtLast.Text.Length < 1 || txtAddress.Text.Length < 1 || txtCity.Text.Length < 1 || txtState.Text.Length < 1)
        {
            return false;
        }
		
        string usZip = @"^\d{5}$|^\d{5}-\d{4}$";
        Regex re = new Regex(usZip);
		return re.IsMatch(txtZip.Text);
