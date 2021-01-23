    if (duplicateVoucherChecker(voucher) &&
        Messages.Question("Podany bon był już użyty na tej stacji", "Uwaga",false) 
            == DialogResult.No)
    {
        ViewTyped.PaymentValueEditor.Focus();
    }
    else
    {
        Vouchers.Add(voucher);
        Payment.OriginalToPay = Payment.ToPay;
        ViewTyped.PaymentNumberEditor.Focus();
        ViewTyped.ChangeEditor.Focus();
    }
