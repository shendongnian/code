	bool dialogShownAndYesNotPicked = false;
	if (duplicateVoucherChecker(voucher))
	{
		DialogResult dialogResult = Messages.Question(
            "Podany bon był już użyty na tej stacji", "Uwaga",
			false);
		if (dialogResult == DialogResult.No)
		{
			ViewTyped.PaymentValueEditor.Focus();
		}
		if (dialogResult != DialogResult.Yes)
		{
			dialogShownAndYesNotPicked = true;
		}       
	}
	
	if(!dialogShownAndNoPicked)
	{
		Vouchers.Add(voucher);
		Payment.OriginalToPay = Payment.ToPay;
		ViewTyped.PaymentNumberEditor.Focus();
		ViewTyped.ChangeEditor.Focus();
	}
