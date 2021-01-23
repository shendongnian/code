    private bool IsValidInputForPaymentForm(string input)
    {
        if(input.Length < 10 || input.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
        
        // other conditions omitted
    }
