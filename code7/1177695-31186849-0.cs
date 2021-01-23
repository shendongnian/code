    private readonly List<CheckoutProcessArgument> checkoutProcessArguments;
    public CustomShoppingCart()
    {
        GetBaseCartSteps();
        CheckoutProcessArgument stepTwoArg = new CheckoutProcessArgument("Step2", new Guid("12345678-1234-1234-1234-123456789012"));
        checkoutProcessArguments = new List<CheckoutProcessArgument> { stepTwoArg };
        BuildCheckoutProcess();
    }
