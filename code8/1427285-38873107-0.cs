    var myCustomer = new StripeCustomerCreateOptions();
        myCustomer.Email = "pork@email.com";
        myCustomer.Description = "Johnny Tenderloin (pork@email.com)";
    
        // setting up the card
        myCustomer.SourceCard = new SourceCard()
        {
            Number = "4242424242424242",
            ExpirationYear = "2022",
            ExpirationMonth = "10",
            Cvc = "1223"                          // optional
        };
    
        myCustomer.PlanId = *planId*;                          // only if you have a plan
        myCustomer.TaxPercent = 20;                            // only if you are passing a plan, this tax percent will be added to the price.
        myCustomer.Coupon = *couponId*;                        // only if you have a coupon
        myCustomer.TrialEnd = DateTime.UtcNow.AddMonths(1);    // when the customers trial ends (overrides the plan if applicable)
        myCustomer.Quantity = 1;                               // optional, defaults to 1
    
        var customerService = new StripeCustomerService();
        StripeCustomer stripeCustomer = customerService.Create(myCustomer)
