    bool duplicateVoucher = duplicateVoucherChecker(voucher);
    bool addVoucher = !duplicateVoucher;
    if(!addVoucher)
    {
        DialogResult dialogResult = Messages.Question("Podany bon był już użyty na tej stacji", "Uwaga", false);
        addVoucher = dialogResult == DialogResult.Yes;
        if (dialogResult == DialogResult.No)     
        {
            ViewTyped.PaymentValueEditor.Focus();
        }
    }
    if(addVoucher)
    {
        Vouchers.Add(voucher);
        Payment.OriginalToPay = Payment.ToPay;
        ViewTyped.PaymentNumberEditor.Focus();
        ViewTyped.ChangeEditor.Focus();
    }
