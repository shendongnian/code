    private decimal? TryConvertToDecimal(String incoming)
    {
        try
        {
            return Convert.ToDecimal(incoming);
        }
        catch
        {
           return null;
        }
    }
    
    var paymentTot = TryConvertToDecimal(boxPaymentAmount.Text);
    if (!paymentTot.HasValue || paymentTot.Value < 0)
    {
        paymentTot = 0;
    }
