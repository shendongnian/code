    if(total >0)
    {
        txtBoxAmountToPay.Text = String.Format("{0:c}", total);
    }
    else
    {
        MessageBox.Show("Please give " + String.Format("{0:c}", -total) + " in change.");
        OnPaymentMade(new PaymentMadeEventArgs(){ PaymentSuccess = true });
    }
