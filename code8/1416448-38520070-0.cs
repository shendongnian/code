    private async void PrintReceipt()
    {
        // Disable the Button to prevent multiple prints
        printReceiptButton.Enabled = false; 
        // ... Logic
    }
    private async void PrintReceipt()
    {
        if(!_hasReceiptPrinted)
        {
            _hasReceiptPrinted = true;
            // ... Logic
        }
    }
