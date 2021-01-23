    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult>  Pay(FormCollection form)
        var amount = form["amount"].ToString();
        var cardExpirtyDate = form["cardExpirtyDate"].ToString();
        var cardHolderName = form["cardHolderName"].ToString();
        var cardNumber = "4111111111111111";
        var customerId = 23;//Internal purpose to track which customer made the transaction....
        var paymentService = new PaymentService(amount, cardExpirtyDate, cardHolderName, cardNumber, customerId.ToString());
        var transactionResult = await paymentService.PostAsync();
        if (transactionResult == null) return View();
    
        if (transactionResult.TransactionApproved && !transactionResult.TransactionError
                && transactionResult.CustomerRef == customerId.ToString())
        {
            //transaction success....Go to payment Response and send the variables
    
            TempData["TRANSACTION_STATUS"] = "APPROVED";
        }
        else
        {
            var message = transactionResult.Message;
        }
        return View();
    }
