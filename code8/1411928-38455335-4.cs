    this.ViewModel.GetDateTime();// WCF async call
    while (this.ViewModel.wcfCallInProgress)
    {
        Thread.Sleep(10);
    }
    this.ViewModel.UpdateValue(value); // another WCF async call, need value from GetDateTime() method's return result.
    this.ViewModel.UpdateAnotherValue(value, user); // third WCF async call
