    bool isbusy;
    private async void PrintReceipt() 
    {
        isbusy = true
        try
        {
          await _printReceiptInteractor.PrintTerminalReceiptAsync(_receipt)
        }
        finally
        {
           //This block will always exeute even if there is an exception
           isbusy = false
        }
    }
