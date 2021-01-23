    private bool _printed = false;
    private async void PrintReceipt()
    {
	    if(!_printed)
		{
		    await _printReceiptInteractor.PrintTerminalReceiptAsync(_receipt).ConfigureAwait(false);
            Dispatcher.Dispatch(() => { this.Close(); });
			
			_printed = true;
		}
    }
