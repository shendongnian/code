    public virtual await Task<IPaymentResult> PurchaseAsync(IDonationEntity donation, ICreditCard creditCard)
    {
        var constituentResponse = await PostConstituentAsync(donation);
        var transactionResponse = await PostTransactionAsync(donation, constituentResponse);
        var donationResponse = await PostDonationAsync(donation, constituentResponse, transactionResponse);
        var creditCardPaymentResponse = await PostCreditCardPaymentAsync(donation, creditCard, transactionResponse);
        var paymentResult = new PaymentResult
        {
            Success = (creditCardPaymentResponse.Status == Constants.PaymentResult.Succeeded),
            ExternalPaymentID = creditCardPaymentResponse.PaymentID,
            ErrorMessage = creditCardPaymentResponse.ErrorMessage
        };
        return paymentResult;
    }
